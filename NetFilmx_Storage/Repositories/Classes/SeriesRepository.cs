using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Series> _dbSet;

        public SeriesRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Series>();
        }

        public List<Series> GetSeries()
        {
            return _dbSet.ToList();
        }

        public Series GetSeriesById(long id)
        {
            return _dbSet.Find(id);
        }

        public void AddSeries(Series series)
        {
            _dbSet.Add(series);
            _context.SaveChanges();
        }

        public void EditSeries(Series series)
        {
            _dbSet.Attach(series);
            _context.Entry(series).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveSeries(long id)
        {
            Series series = _dbSet.Find(id);
            if (series != null)
            {
                _dbSet.Remove(series);
                _context.SaveChanges();
            }
        }
    }
}
