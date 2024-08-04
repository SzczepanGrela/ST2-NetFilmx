using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Context;
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

        public async Task UpdateSeriesPurchaseAsync(SeriesPurchase seriesPurchase)
        {
            if (seriesPurchase == null)
            {
                throw new ArgumentNullException(nameof(seriesPurchase), "Series purchase cannot be null");
            }

            if (!await IsSeriesPurchaseExistAsync(seriesPurchase.Id))
            {
                throw new ArgumentException("Series purchase not found");
            }

            _context.SeriesPurchases.Attach(seriesPurchase);
            _context.Entry(seriesPurchase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeriesPurchaseAsync(int seriesId, int userId)
        {
            var seriesPurchase = await _context.SeriesPurchases
        .FirstOrDefaultAsync(sp => sp.SeriesId == seriesId && sp.UserId == userId);

            if (seriesPurchase == null)
            {
                throw new ArgumentException("Series purchase not found");
            }

            _context.SeriesPurchases.Remove(seriesPurchase);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsSeriesPurchaseExistAsync(int seriesPurchaseId)
        {
            return await _context.SeriesPurchases.AnyAsync(sp => sp.Id == seriesPurchaseId);
        }

        public async Task<bool> IsSeriesPurchaseExistAsync(int userId, int seriesId)
        {
            if (!await _context.Users.AnyAsync(u => u.Id == userId))
            {
                throw new ArgumentException("User not found");
            }

            if (!await _context.Series.AnyAsync(s => s.Id == seriesId))
            {
                throw new ArgumentException("Series not found");
            }

            return await _context.SeriesPurchases.AnyAsync(sp => sp.UserId == userId && sp.SeriesId == seriesId);
        }


        public async Task<List<SeriesPurchase>> GetAllSeriesPurchasesAsync()
        {
            return await _context.SeriesPurchases.ToListAsync();
        }


        public async Task<SeriesPurchase> GetSeriesPurchaseByIdAsync(int seriesPurchaseId)
        {
            var seriesPurchase = await _context.SeriesPurchases.FindAsync(seriesPurchaseId);
            return seriesPurchase ?? throw new ArgumentException("Series purchase not found");
        }


        public async Task<SeriesPurchase> GetSeriesPurchaseByUserIdSeriesIdAsync(int userId, int seriesId)
        {
            var seriesPurchase = await _context.SeriesPurchases.FirstOrDefaultAsync(sp => sp.UserId == userId && sp.SeriesId == seriesId);
            return seriesPurchase ?? throw new ArgumentException("Series purchase not found");
        }


        public async Task<List<SeriesPurchase>> GetSeriesPurchasesByUserIdAsync(int userId)
        {
            if (!await _context.Users.AnyAsync(u => u.Id == userId))
            {
                throw new ArgumentException("User not found");
            }

            return await _context.SeriesPurchases.Where(sp => sp.UserId == userId).ToListAsync();
        }

        public async Task<List<SeriesPurchase>> GetSeriesPurchasesBySeriesIdAsync(int seriesId)
        {
            if (!await _context.Series.AnyAsync(s => s.Id == seriesId))
            {
                throw new ArgumentException("Series not found");
            }

            return await _context.SeriesPurchases.Where(sp => sp.SeriesId == seriesId).ToListAsync();
        }




    }
}
