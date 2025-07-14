using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Context;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly NetFilmxDbContext _context;

        public FavoriteRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public async Task<Favorite> AddAsync(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();
            return favorite;
        }

        public async Task<Favorite?> GetByIdAsync(int id)
        {
            return await _context.Favorites
                .Include(f => f.Video)
                .Include(f => f.Series)
                .Include(f => f.User)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Favorite>> GetByUserIdAsync(int userId)
        {
            return await _context.Favorites
                .Include(f => f.Video)
                .Include(f => f.Series)
                .Where(f => f.UserId == userId)
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }

        public async Task<Favorite?> GetByUserAndVideoAsync(int userId, int videoId)
        {
            return await _context.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.VideoId == videoId);
        }

        public async Task<Favorite?> GetByUserAndSeriesAsync(int userId, int seriesId)
        {
            return await _context.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.SeriesId == seriesId);
        }

        public async Task DeleteAsync(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Favorite>> GetAllAsync()
        {
            return await _context.Favorites
                .Include(f => f.Video)
                .Include(f => f.Series)
                .Include(f => f.User)
                .ToListAsync();
        }
    }
}