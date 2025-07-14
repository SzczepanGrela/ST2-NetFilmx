using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Service.Dtos.VideoPurchase;
using NetFilmx_Service.Dtos.SeriesPurchase;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Dtos.Favorite;
using NetFilmx_Service.Dtos.ViewHistory;
using NetFilmx_User.Models;
using NetFilmx_User.Models.ViewModels;
using NetFilmx_User.Services;
using System.Security.Claims;

namespace NetFilmx_User.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IUserSyncService _userSyncService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(IApiService apiService, IUserSyncService userSyncService, UserManager<ApplicationUser> userManager)
        {
            _apiService = apiService;
            _userSyncService = userSyncService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            try
            {
                // Get the current ApplicationUser
                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return RedirectToAction("Login", "Account", new { area = "Identity" });
                }

                // Sync and get NetFilmx User ID
                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);

                // Create real profile view with actual user data
                var viewModel = new ProfileViewModel
                {
                    User = new UserDetailsDto(
                        id: netFilmxUserId,
                        username: applicationUser.DisplayName ?? applicationUser.UserName ?? "User",
                        email: applicationUser.Email ?? "user@example.com",
                        createdAt: applicationUser.CreatedAt,
                        updatedAt: applicationUser.UpdatedAt
                    )
                };

                // Get user's favorites to show as recommendations
                var userFavorites = await _apiService.GetUserFavoritesAsync(netFilmxUserId);
                
                // Get all videos for general recommendations
                var allVideos = await _apiService.GetAllVideosAsync();
                if (allVideos != null)
                {
                    var videoList = allVideos.ToList();
                    viewModel.RecommendedVideos = videoList.Take(6).ToList();
                    viewModel.TrendingVideos = videoList.Skip(6).Take(6).ToList();
                }
                else
                {
                    viewModel.RecommendedVideos = new List<VideoListDto>();
                    viewModel.TrendingVideos = new List<VideoListDto>();
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                // Log error and fall back to basic view
                return RedirectToAction("Error", "Home", new { errorMessage = "Error loading profile", errors = new[] { ex.Message } });
            }
        }

        public async Task<IActionResult> Purchases()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            try
            {
                // Get current user and sync
                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return RedirectToAction("Login", "Account", new { area = "Identity" });
                }

                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);

                // Get user's purchase history from API
                var videoPurchases = await _apiService.GetUserVideoPurchasesAsync(netFilmxUserId);
                var seriesPurchases = await _apiService.GetUserSeriesPurchasesAsync(netFilmxUserId);

                var viewModel = new PurchaseHistoryViewModel
                {
                    VideoPurchases = videoPurchases?.ToList() ?? new List<VideoPurchaseDetailsDto>(),
                    SeriesPurchases = seriesPurchases?.ToList() ?? new List<SeriesPurchaseDetailsDto>()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Error loading purchase history", errors = new[] { ex.Message } });
            }
        }

        public async Task<IActionResult> Edit()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            try
            {
                // Get current user and sync
                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return RedirectToAction("Login", "Account", new { area = "Identity" });
                }

                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);

                // Get user profile from API
                var userProfile = await _apiService.GetUserProfileAsync(netFilmxUserId);
                if (userProfile == null)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Unable to load user profile" });
                }

                var userEdit = new UserEditDto
                {
                    Id = userProfile.Id,
                    Username = userProfile.Username,
                    Email = userProfile.Email
                };

                return View(userEdit);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Error loading profile for editing", errors = new[] { ex.Message } });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            try
            {
                // Get current user and sync
                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return RedirectToAction("Login", "Account", new { area = "Identity" });
                }

                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);

                // Update profile through API
                var updateSuccess = await _apiService.UpdateUserProfileAsync(netFilmxUserId, model);
                
                if (updateSuccess)
                {
                    TempData["SuccessMessage"] = "Profile updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to update profile. Please try again.");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating profile: {ex.Message}");
                return View(model);
            }
        }

        public async Task<IActionResult> Settings()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            try
            {
                // Get current user and sync
                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return RedirectToAction("Login", "Account", new { area = "Identity" });
                }

                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);

                // Get user's settings from API
                var settings = await _apiService.GetUserSettingsAsync(netFilmxUserId);
                
                return View(settings);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Error loading settings", errors = new[] { ex.Message } });
            }
        }

        public async Task<IActionResult> Favorites()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            try
            {
                // Get current user and sync
                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return RedirectToAction("Login", "Account", new { area = "Identity" });
                }

                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);

                // Get user's favorites from API
                var favorites = await _apiService.GetUserFavoritesAsync(netFilmxUserId);
                
                return View(favorites ?? new List<FavoriteListDto>());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Error loading favorites", errors = new[] { ex.Message } });
            }
        }

        public async Task<IActionResult> ViewHistory()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            try
            {
                // Get current user and sync
                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return RedirectToAction("Login", "Account", new { area = "Identity" });
                }

                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);

                // Get user's view history from API
                var viewHistory = await _apiService.GetUserViewHistoryAsync(netFilmxUserId);
                
                return View(viewHistory ?? new List<ViewHistoryDetailsDto>());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Error loading view history", errors = new[] { ex.Message } });
            }
        }

        private int? GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdClaim, out int userId))
            {
                return userId;
            }
            return null;
        }
    }
}