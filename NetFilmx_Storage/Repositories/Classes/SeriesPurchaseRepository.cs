using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public class SeriesPurchaseRepository : ISeriesPurchaseRepository
    {

        private readonly NetFilmxDbContext _context;

        public SeriesPurchaseRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public async Task AddSeriesPurchaseAsync(SeriesPurchase seriesPurchase)
        {
            if (seriesPurchase == null)
            {
                throw new ArgumentNullException(nameof(seriesPurchase), "Series purchase cannot be null");
            }
            if (await IsSeriesPurchaseExistAsync(seriesPurchase.UserId, seriesPurchase.SeriesId))
            {
                throw new InvalidOperationException("The series purchase already exists");
            }
            await _context.SeriesPurchases.AddAsync(seriesPurchase);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeriesPurchaseAsync(int seriesPurchaseId)
        {
            var seriesPurchase = await GetSeriesPurchaseByIdAsync(seriesPurchaseId);
            if (seriesPurchase == null)
            {
                throw new Exception("Series purchase not found");
            }
            _context.SeriesPurchases.Remove(seriesPurchase);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SeriesPurchase>> GetAllSeriesPurchasesAsync()
        {
            return await _context.SeriesPurchases.ToListAsync();
        }

        public async Task<SeriesPurchase> GetSeriesPurchaseByIdAsync(int seriesPurchaseId)
        {
            var seriesPurchase = await _context.SeriesPurchases.FindAsync(seriesPurchaseId);
            return seriesPurchase ?? throw new Exception("Series purchase not found");
        }

        public async Task<List<SeriesPurchase>> GetSeriesPurchasesBySeriesIdAsync(int seriesId)
        {
            var series = await _context.Series.FindAsync(seriesId);
            if (series == null)
            {
                throw new Exception("Series not found");
            }
            return await _context.SeriesPurchases.Where(sp => sp.SeriesId == seriesId).ToListAsync();
        }

        public async Task<List<SeriesPurchase>> GetSeriesPurchasesByUserIdAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return await _context.SeriesPurchases.Where(sp => sp.UserId == userId).ToListAsync();
        }

        public async Task<bool> IsSeriesPurchaseExistAsync(int userId, int seriesId)
        {
            if (!await _context.Users.AnyAsync(u => u.Id == userId))
            {
                throw new Exception("User not found");
            }
            if (!await _context.Series.AnyAsync(s => s.Id == seriesId))
            {
                throw new Exception("Series not found");
            }
            return await _context.SeriesPurchases.AnyAsync(sp => sp.UserId == userId && sp.SeriesId == seriesId);
        }

        public async Task<bool> IsSeriesPurchaseExistAsync(int seriesPurchaseId)
        {
            return await _context.SeriesPurchases.AnyAsync(sp => sp.Id == seriesPurchaseId);
        }

        public async Task UpdateSeriesPurchaseAsync(SeriesPurchase seriesPurchase)
        {
            if (seriesPurchase == null)
            {
                throw new ArgumentNullException(nameof(seriesPurchase), "Series purchase cannot be null");
            }
            if (!await IsSeriesPurchaseExistAsync(seriesPurchase.Id))
            {
                throw new Exception("Series purchase not found");
            }
            _context.SeriesPurchases.Attach(seriesPurchase);
            _context.Entry(seriesPurchase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }


}
