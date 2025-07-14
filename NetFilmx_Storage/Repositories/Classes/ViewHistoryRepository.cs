using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Context;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public class ViewHistoryRepository : IViewHistoryRepository
    {
        private readonly NetFilmxDbContext _context;

        public ViewHistoryRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public async Task<ViewHistory> AddAsync(ViewHistory viewHistory)
        {
            _context.ViewHistory.Add(viewHistory);
            await _context.SaveChangesAsync();
            return viewHistory;
        }

        public async Task<ViewHistory?> GetByIdAsync(int id)
        {
            return await _context.ViewHistory
                .Include(vh => vh.User)
                .Include(vh => vh.Video)
                .FirstOrDefaultAsync(vh => vh.Id == id);
        }

        public async Task<ViewHistory?> GetByUserAndVideoAsync(int userId, int videoId)
        {
            return await _context.ViewHistory
                .Include(vh => vh.User)
                .Include(vh => vh.Video)
                .FirstOrDefaultAsync(vh => vh.UserId == userId && vh.VideoId == videoId);
        }

        public async Task<IEnumerable<ViewHistory>> GetByUserIdAsync(int userId, int take = 50)
        {
            return await _context.ViewHistory
                .Include(vh => vh.Video)
                .Where(vh => vh.UserId == userId)
                .OrderByDescending(vh => vh.ViewedAt)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<ViewHistory>> GetRecentByUserIdAsync(int userId, int days = 30, int take = 20)
        {
            var cutoffDate = DateTime.Now.AddDays(-days);
            return await _context.ViewHistory
                .Include(vh => vh.Video)
                .Where(vh => vh.UserId == userId && vh.ViewedAt >= cutoffDate)
                .OrderByDescending(vh => vh.ViewedAt)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<ViewHistory>> GetContinueWatchingAsync(int userId, int take = 10)
        {
            return await _context.ViewHistory
                .Include(vh => vh.Video)
                .Where(vh => vh.UserId == userId && 
                           vh.WatchTimeSeconds > 0 && 
                           vh.VideoDurationSeconds.HasValue &&
                           vh.WatchTimeSeconds < vh.VideoDurationSeconds * 0.9) // Not completed
                .OrderByDescending(vh => vh.UpdatedAt)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<ViewHistory>> GetCompletedByUserIdAsync(int userId, int take = 50)
        {
            return await _context.ViewHistory
                .Include(vh => vh.Video)
                .Where(vh => vh.UserId == userId && 
                           vh.VideoDurationSeconds.HasValue &&
                           vh.WatchTimeSeconds >= vh.VideoDurationSeconds * 0.9) // Completed
                .OrderByDescending(vh => vh.ViewedAt)
                .Take(take)
                .ToListAsync();
        }

        public async Task UpdateAsync(ViewHistory viewHistory)
        {
            viewHistory.UpdatedAt = DateTime.Now;
            _context.ViewHistory.Update(viewHistory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWatchProgressAsync(int userId, int videoId, int watchTimeSeconds, int? videoDurationSeconds = null)
        {
            var existingRecord = await GetByUserAndVideoAsync(userId, videoId);
            
            if (existingRecord == null)
            {
                // Create new record
                var newRecord = new ViewHistory(userId, videoId, watchTimeSeconds)
                {
                    VideoDurationSeconds = videoDurationSeconds
                };
                await AddAsync(newRecord);
            }
            else
            {
                // Update existing record
                existingRecord.WatchTimeSeconds = Math.Max(existingRecord.WatchTimeSeconds, watchTimeSeconds); // Keep highest progress
                existingRecord.ViewedAt = DateTime.Now;
                existingRecord.UpdatedAt = DateTime.Now;
                
                if (videoDurationSeconds.HasValue)
                {
                    existingRecord.VideoDurationSeconds = videoDurationSeconds;
                }

                await UpdateAsync(existingRecord);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var viewHistory = await _context.ViewHistory.FindAsync(id);
            if (viewHistory != null)
            {
                _context.ViewHistory.Remove(viewHistory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteByUserAndVideoAsync(int userId, int videoId)
        {
            var viewHistory = await _context.ViewHistory
                .FirstOrDefaultAsync(vh => vh.UserId == userId && vh.VideoId == videoId);
            
            if (viewHistory != null)
            {
                _context.ViewHistory.Remove(viewHistory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ViewHistory>> GetAllAsync()
        {
            return await _context.ViewHistory
                .Include(vh => vh.User)
                .Include(vh => vh.Video)
                .OrderByDescending(vh => vh.ViewedAt)
                .ToListAsync();
        }

        public async Task<int> GetWatchTimeByUserIdAsync(int userId)
        {
            return await _context.ViewHistory
                .Where(vh => vh.UserId == userId)
                .SumAsync(vh => vh.WatchTimeSeconds);
        }

        public async Task<IEnumerable<ViewHistory>> GetMostWatchedVideosAsync(int userId, int take = 10)
        {
            return await _context.ViewHistory
                .Include(vh => vh.Video)
                .Where(vh => vh.UserId == userId)
                .GroupBy(vh => vh.VideoId)
                .Select(g => g.OrderByDescending(vh => vh.WatchTimeSeconds).First())
                .OrderByDescending(vh => vh.WatchTimeSeconds)
                .Take(take)
                .ToListAsync();
        }
    }
}