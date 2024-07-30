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
            _context.SeriesPurchases.Add(seriesPurchase);
            _context.SaveChanges();
        }

        public void DeleteSeriesPurchase(int seriesPurchaseId)
        {
            _context.SeriesPurchases.Remove(GetSeriesPurchaseById(seriesPurchaseId));
            _context.SaveChanges();
        }

        public List<SeriesPurchase> GetAllSeriesPurchases()
        {
            return _context.SeriesPurchases.ToList();
        }

        public SeriesPurchase GetSeriesPurchaseById(int seriesPurchaseId)
        {
            return _context.SeriesPurchases.Find(seriesPurchaseId) ?? throw new Exception("Series purchase not found");
        }

        public List<SeriesPurchase> GetSeriesPurchasesBySeriesId(int seriesId)
        {
            return _context.SeriesPurchases.Where(sp => sp.SeriesId == seriesId).ToList();
        }

        public List<SeriesPurchase> GetSeriesPurchasesByUserId(int userId)
        {
            return _context.SeriesPurchases.Where(sp => sp.UserId == userId).ToList();
        }

        public bool IsSeriesPurchaseExist(int userId, int seriesId)
        {
            return _context.SeriesPurchases.Any(sp => sp.UserId == userId && sp.SeriesId == seriesId);
        }

        public bool IsSeriesPurchaseExist(int seriesPurchaseId)
        {
           return _context.SeriesPurchases.Any(sp => sp.Id == seriesPurchaseId);
        }

        public void UpdateSeriesPurchase(SeriesPurchase seriesPurchase)
        {
            _context.SeriesPurchases.Attach(seriesPurchase);
            _context.Entry(seriesPurchase).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }


}
