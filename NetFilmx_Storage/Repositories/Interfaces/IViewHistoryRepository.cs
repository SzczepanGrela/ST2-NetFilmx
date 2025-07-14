using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public interface IViewHistoryRepository
    {
        Task<ViewHistory> AddAsync(ViewHistory viewHistory);
        Task<ViewHistory?> GetByIdAsync(int id);
        Task<ViewHistory?> GetByUserAndVideoAsync(int userId, int videoId);
        Task<IEnumerable<ViewHistory>> GetByUserIdAsync(int userId, int take = 50);
        Task<IEnumerable<ViewHistory>> GetRecentByUserIdAsync(int userId, int days = 30, int take = 20);
        Task<IEnumerable<ViewHistory>> GetContinueWatchingAsync(int userId, int take = 10);
        Task<IEnumerable<ViewHistory>> GetCompletedByUserIdAsync(int userId, int take = 50);
        Task UpdateAsync(ViewHistory viewHistory);
        Task UpdateWatchProgressAsync(int userId, int videoId, int watchTimeSeconds, int? videoDurationSeconds = null);
        Task DeleteAsync(int id);
        Task DeleteByUserAndVideoAsync(int userId, int videoId);
        Task<IEnumerable<ViewHistory>> GetAllAsync();
        Task<int> GetWatchTimeByUserIdAsync(int userId); // Total watch time in seconds
        Task<IEnumerable<ViewHistory>> GetMostWatchedVideosAsync(int userId, int take = 10);
    }
}