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

        public List<Series> GetAllSeries()
        {
            return _context.Series.ToList();
        }

        public Series GetSeriesById(int id)
        {
            Series? series = _context.Series.Find(id);
            return series == null ? throw new Exception("Series not found") : series;
        }

        public void AddSeries(Series series)
        {
            _context.Series.Add(series);
            _context.SaveChanges();
        }

        public void EditSeries(Series series)
        {
            _context.Series.Attach(series);
            _context.Entry(series).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteSeries(int id)
        {
            Series? series = _context.Series.Find(id);
            if (series != null)
            {
                _context.Series.Remove(series);
                _context.SaveChanges();
            }
        }

        public bool IsSeriesExist(string name)
        {
            return _context.Series.Any(c => c.Name == name);
        }
    }
}
