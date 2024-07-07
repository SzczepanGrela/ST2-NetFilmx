using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class VideoSeriesRepository : IVideoSeriesRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<VideoSeries> _dbSet;

        public VideoSeriesRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<VideoSeries>();
        }

        public List<VideoSeries> GetVideoSeriesBySeriesId(long seriesId)
        {
            return _dbSet.Where(vs => vs.SeriesId == seriesId).ToList();
        }

        public void AddVideoSeries(VideoSeries videoSeries)
        {
            _dbSet.Add(videoSeries);
            _context.SaveChanges();
        }

        public void RemoveVideoSeries(long id)
        {
            VideoSeries videoSeries = _dbSet.Find(id);
            if (videoSeries != null)
            {
                _dbSet.Remove(videoSeries);
                _context.SaveChanges();
            }
        }
    }
}
