using NetFilmx_User.Models;

namespace NetFilmx_User.Services
{
    public interface IUserSyncService
    {
        /// <summary>
        /// Synchronizes ApplicationUser with NetFilmx User entity
        /// Creates NetFilmx User if doesn't exist, links them together
        /// </summary>
        Task<int> SyncUserAsync(ApplicationUser applicationUser);

        /// <summary>
        /// Gets the NetFilmx User ID for the given ApplicationUser
        /// </summary>
        Task<int?> GetNetFilmxUserIdAsync(ApplicationUser applicationUser);

        /// <summary>
        /// Gets the NetFilmx User ID for the current logged in user
        /// </summary>
        Task<int?> GetCurrentNetFilmxUserIdAsync();

        /// <summary>
        /// Updates ApplicationUser properties from NetFilmx User
        /// </summary>
        Task UpdateApplicationUserFromNetFilmxAsync(ApplicationUser applicationUser);

        /// <summary>
        /// Updates NetFilmx User properties from ApplicationUser
        /// </summary>
        Task UpdateNetFilmxUserFromApplicationAsync(ApplicationUser applicationUser);

        /// <summary>
        /// Ensures the user is properly synced and returns NetFilmx User ID
        /// </summary>
        Task<int> EnsureUserSyncedAsync(string? userEmail);
    }
}