using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly NetFilmxDbContext _context;

        public SeriesRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public async Task<List<Series>> GetAllSeriesAsync()
        {
            return await _context.Series.ToListAsync();
        }

        public async Task<List<Series>> GetSeriesByVideoIdAsync(int videoId)
        {
            if (!await _context.Videos.AnyAsync(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }

            return await _context.Videos.Where(v => v.Id == videoId).SelectMany(v => v.Series).ToListAsync();
        }

        public async Task<List<Series>> GetBoughtSeriesByUserIdAsync(int userId)
        {
            if (!await _context.Users.AnyAsync(u => u.Id == userId))
            {
                throw new Exception("User not found");
            }
            return await _context.Series.Include(s => s.SeriesPurchases).Where(s => s.SeriesPurchases.Any(p => p.UserId == userId)).ToListAsync();
        }

        public async Task<Series> GetSeriesByIdAsync(int seriesId)
        {
            var series = await _context.Series.FindAsync(seriesId);
            return series ?? throw new Exception("Series not found");
        }

        public async Task<Series> GetSeriesByNameAsync(string seriesName)
        {
            var series = await _context.Series.FirstOrDefaultAsync(c => c.Name == seriesName);
            return series ?? throw new Exception("Series not found");
        }

        public async Task AddSeriesAsync(Series series)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series), "Series cannot be null");
            }
            if (await IsSeriesExistAsync(series.Name))
            {
                throw new InvalidOperationException("A series with this name already exists");
            }
            await _context.Series.AddAsync(series);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSeriesAsync(Series series)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series), "Series cannot be null");
            }
            if (!await IsSeriesExistAsync(series.Id))
            {
                throw new Exception("Series not found");
            }
            _context.Series.Attach(series);
            _context.Entry(series).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeriesAsync(int seriesId)
        {
            var series = await _context.Series.FindAsync(seriesId);
            if (series == null)
            {
                throw new Exception("Series not found");
            }
            _context.Series.Remove(series);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsSeriesExistAsync(string seriesName)
        {
            return await _context.Series.AnyAsync(c => c.Name == seriesName);
        }

        public async Task<bool> IsSeriesExistAsync(int seriesId)
        {
            return await _context.Series.AnyAsync(c => c.Id == seriesId);
        }

        public async Task<int> GetSeriesCountByIdAsync(int seriesId)
        {
            return await _context.Series.Include(c => c.Videos).Where(s => s.Id == seriesId).SelectMany(s => s.Videos).CountAsync();
        }

        public async Task<int> GetSeriesCountByNameAsync(string seriesName)
        {
            return await _context.Series.Include(c => c.Videos).Where(s => s.Name == seriesName).SelectMany(s => s.Videos).CountAsync();
        }




    }
}
