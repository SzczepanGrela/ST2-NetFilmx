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

        public List<Series> GetSeriesByVideoId(int videoId)
        {
            if(!_context.Videos.Any(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }

            return _context.Videos.Where(v => v.Id == videoId).SelectMany(v => v.Series).ToList();

        }

        public List<Series> GetBoughtSeriesByUserId(int userId)
        {
            if(!_context.Users.Any(u => u.Id == userId))
            {
                throw new Exception("User not found");
            }
            return _context.Series.Include(s => s.SeriesPurchases).Where(s => s.SeriesPurchases.Any(p => p.UserId == userId)).ToList();
        }



        public Series GetSeriesById(int seriesId)
        {
            var series = _context.Series.Find(seriesId);
            return series == null ? throw new Exception("Series not found") : series;
        }

        public Series GetSeriesByName(string seriesName)
        {
            var series = _context.Series.FirstOrDefault(c => c.Name == seriesName);
            return series == null ? throw new Exception("Series not found") : series;
        }


        public void AddSeries(Series series)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series), "Series cannot be null");
            }
            if (IsSeriesExist(series.Name))
            {
                throw new InvalidOperationException("A series with this name already exists");
            }
            _context.Series.Add(series);
            _context.SaveChanges();
        }

        public void UpdateSeries(Series series)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series), "Series cannot be null");
            }
            if (!IsSeriesExist(series.Id))
            {
                throw new Exception("Series not found");
            }
            _context.Series.Attach(series);
            _context.Entry(series).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteSeries(int seriesId)
        {
            var series = _context.Series.Find(seriesId) ?? throw new Exception("Series not found");
            _context.Series.Remove(series);
            _context.SaveChanges();
        }

        public bool IsSeriesExist(string seriesName)
        {
            return _context.Series.Any(c => c.Name == seriesName);
        }

        public bool IsSeriesExist(int seriesId)
        {
            return _context.Series.Any(c => c.Id == seriesId);
        }
    }
}
