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

        public List<VideoSeries> GetVideoSeriesBySeriesId(int seriesId)
        {
            return _dbSet.Where(vs => vs.SeriesId == seriesId).ToList();
        }


        public VideoSeries GetVideoSeriesByVideoIdSeriesId(int videoId, int seriesId)
        {
            var videoSeries = _dbSet.Find(videoId, seriesId);
            if (videoSeries == null)
            {
                throw new Exception("VideoSeries not found");
            }
            return videoSeries;
        }



        public void AddVideoSeries(VideoSeries videoSeries)
        {
            _dbSet.Add(videoSeries);
            _context.SaveChanges();
        }

        public void DeleteVideoSeries(int id)
        {
            VideoSeries? videoSeries = _dbSet.Find(id);
            if (videoSeries != null)
            {
                _dbSet.Remove(videoSeries);
                _context.SaveChanges();
            }
        }

        public bool IsVideoSeriesExist(int video_Id, int series_Id)
        {
           return _dbSet.Any(vs => vs.VideoId == video_Id && vs.SeriesId == series_Id);
        }
    }
}
