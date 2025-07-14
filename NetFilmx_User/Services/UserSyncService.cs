using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetFilmx_User.Data;
using NetFilmx_User.Models;
using NetFilmx_Storage.Repositories;
using System.Security.Claims;

namespace NetFilmx_User.Services
{
    public class UserSyncService : IUserSyncService
    {
        private readonly ApplicationDbContext _identityContext;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UserSyncService> _logger;

        public UserSyncService(
            ApplicationDbContext identityContext,
            IUserRepository userRepository,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            ILogger<UserSyncService> logger)
        {
            _identityContext = identityContext;
            _userRepository = userRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<int> SyncUserAsync(ApplicationUser applicationUser)
        {
            try
            {
                // Check if already linked
                if (applicationUser.NetFilmxUserId.HasValue)
                {
                    var existingUser = await _userRepository.GetByIdAsync(applicationUser.NetFilmxUserId.Value);
                    if (existingUser != null)
                    {
                        return applicationUser.NetFilmxUserId.Value;
                    }
                }

                // Check if NetFilmx user exists by email
                var netFilmxUser = await _userRepository.GetByEmailAsync(applicationUser.Email!);
                
                if (netFilmxUser == null)
                {
                    // Create new NetFilmx user
                    netFilmxUser = new NetFilmx_Storage.Entities.User(
                        applicationUser.UserName ?? applicationUser.Email!,
                        applicationUser.Email!,
                        "IDENTITY_MANAGED" // Placeholder since password is managed by Identity
                    );
                    
                    netFilmxUser = await _userRepository.AddAsync(netFilmxUser);
                    _logger.LogInformation("Created new NetFilmx user {UserId} for Identity user {IdentityId}", 
                        netFilmxUser.Id, applicationUser.Id);
                }

                // Link ApplicationUser to NetFilmx User
                if (applicationUser.NetFilmxUserId != netFilmxUser.Id)
                {
                    applicationUser.NetFilmxUserId = netFilmxUser.Id;
                    applicationUser.UpdatedAt = DateTime.Now;
                    
                    _identityContext.Users.Update(applicationUser);
                    await _identityContext.SaveChangesAsync();
                    
                    _logger.LogInformation("Linked Identity user {IdentityId} to NetFilmx user {UserId}", 
                        applicationUser.Id, netFilmxUser.Id);
                }

                return netFilmxUser.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error syncing user {IdentityId}", applicationUser.Id);
                throw;
            }
        }

        public async Task<int?> GetNetFilmxUserIdAsync(ApplicationUser applicationUser)
        {
            if (applicationUser.NetFilmxUserId.HasValue)
            {
                return applicationUser.NetFilmxUserId.Value;
            }

            // Try to sync and return the ID
            try
            {
                return await SyncUserAsync(applicationUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting NetFilmx user ID for {IdentityId}", applicationUser.Id);
                return null;
            }
        }

        public async Task<int?> GetCurrentNetFilmxUserIdAsync()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null || !user.Identity!.IsAuthenticated)
            {
                return null;
            }

            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                return null;
            }

            var applicationUser = await _userManager.FindByIdAsync(userIdClaim);
            if (applicationUser == null)
            {
                return null;
            }

            return await GetNetFilmxUserIdAsync(applicationUser);
        }

        public async Task UpdateApplicationUserFromNetFilmxAsync(ApplicationUser applicationUser)
        {
            if (!applicationUser.NetFilmxUserId.HasValue)
            {
                return;
            }

            var netFilmxUser = await _userRepository.GetByIdAsync(applicationUser.NetFilmxUserId.Value);
            if (netFilmxUser == null)
            {
                return;
            }

            // Update ApplicationUser from NetFilmx User
            var updated = false;

            if (applicationUser.Email != netFilmxUser.Email)
            {
                applicationUser.Email = netFilmxUser.Email;
                applicationUser.NormalizedEmail = netFilmxUser.Email.ToUpperInvariant();
                updated = true;
            }

            if (applicationUser.UserName != netFilmxUser.Username)
            {
                applicationUser.UserName = netFilmxUser.Username;
                applicationUser.NormalizedUserName = netFilmxUser.Username.ToUpperInvariant();
                updated = true;
            }

            if (string.IsNullOrEmpty(applicationUser.DisplayName))
            {
                applicationUser.DisplayName = netFilmxUser.Username;
                updated = true;
            }

            if (updated)
            {
                applicationUser.UpdatedAt = DateTime.Now;
                _identityContext.Users.Update(applicationUser);
                await _identityContext.SaveChangesAsync();
            }
        }

        public async Task UpdateNetFilmxUserFromApplicationAsync(ApplicationUser applicationUser)
        {
            if (!applicationUser.NetFilmxUserId.HasValue)
            {
                return;
            }

            var netFilmxUser = await _userRepository.GetByIdAsync(applicationUser.NetFilmxUserId.Value);
            if (netFilmxUser == null)
            {
                return;
            }

            // Update NetFilmx User from ApplicationUser
            var updated = false;

            if (netFilmxUser.Email != applicationUser.Email)
            {
                netFilmxUser.Email = applicationUser.Email!;
                updated = true;
            }

            if (netFilmxUser.Username != applicationUser.UserName)
            {
                netFilmxUser.Username = applicationUser.UserName!;
                updated = true;
            }

            if (updated)
            {
                netFilmxUser.UpdatedAt = DateTime.Now;
                await _userRepository.UpdateAsync(netFilmxUser);
            }
        }

        public async Task<int> EnsureUserSyncedAsync(string? userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
            {
                throw new ArgumentException("User email is required", nameof(userEmail));
            }

            var applicationUser = await _userManager.FindByEmailAsync(userEmail);
            if (applicationUser == null)
            {
                throw new InvalidOperationException($"ApplicationUser not found for email: {userEmail}");
            }

            return await SyncUserAsync(applicationUser);
        }
    }
}