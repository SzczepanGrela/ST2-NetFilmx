using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public class SeriesPurchaseRepository : ISeriesPurchaseRepository
    {

        private readonly NetFilmxDbContext _context;

        public void AddSeriesPurchase(SeriesPurchase seriesPurchase)
        {
            if (seriesPurchase == null)
            {
                throw new ArgumentNullException(nameof(seriesPurchase), "Series purchase cannot be null");
            }
            if (IsSeriesPurchaseExist(seriesPurchase.UserId, seriesPurchase.SeriesId))
            {
                throw new InvalidOperationException("The series purchase already exists");
            }
            _context.SeriesPurchases.Add(seriesPurchase);
            _context.SaveChanges();
        }

        public void DeleteSeriesPurchase(int seriesPurchaseId)
        {
            var seriesPurchase = GetSeriesPurchaseById(seriesPurchaseId);
            if (seriesPurchase == null)
            {
                throw new Exception("Series purchase not found");
            }
            _context.SeriesPurchases.Remove(seriesPurchase);
            _context.SaveChanges();
        }

        public List<SeriesPurchase> GetAllSeriesPurchases()
        {
            return _context.SeriesPurchases.ToList();
        }

        public SeriesPurchase GetSeriesPurchaseById(int seriesPurchaseId)
        {
            var seriesPurchase = _context.SeriesPurchases.Find(seriesPurchaseId);
            if (seriesPurchase == null)
            {
                throw new Exception("Series purchase not found");
            }
            return seriesPurchase;
        }

        public List<SeriesPurchase> GetSeriesPurchasesBySeriesId(int seriesId)
        {
            var series = _context.Series.Find(seriesId);
            if (series == null)
            {
                throw new Exception("Series not found");
            }
            return _context.SeriesPurchases.Where(sp => sp.SeriesId == seriesId).ToList();
        }

        public List<SeriesPurchase> GetSeriesPurchasesByUserId(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return _context.SeriesPurchases.Where(sp => sp.UserId == userId).ToList();
        }

        public bool IsSeriesPurchaseExist(int userId, int seriesId)
        {
            if (!_context.Users.Any(u => u.Id == userId))
            {
                throw new Exception("User not found");
            }
            if (!_context.Series.Any(s => s.Id == seriesId))
            {
                throw new Exception("Series not found");
            }
            return _context.SeriesPurchases.Any(sp => sp.UserId == userId && sp.SeriesId == seriesId);
        }

        public bool IsSeriesPurchaseExist(int seriesPurchaseId)
        {
           return _context.SeriesPurchases.Any(sp => sp.Id == seriesPurchaseId);
        }

        public void UpdateSeriesPurchase(SeriesPurchase seriesPurchase)
        {
            if (seriesPurchase == null)
            {
                throw new ArgumentNullException(nameof(seriesPurchase), "Series purchase cannot be null");
            }
            if (!IsSeriesPurchaseExist(seriesPurchase.Id))
            {
                throw new Exception("Series purchase not found");
            }
            _context.SeriesPurchases.Attach(seriesPurchase);
            _context.Entry(seriesPurchase).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }
    }


}
