using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class VideoSeriesRepository : IVideoSeriesRepository
    {
        private readonly NetFilmxDbContext _context;

        public VideoSeriesRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public List<VideoSeries> GetVideoSeriesBySeriesId(int seriesId)
        {
            return _context.VideoSeries.Where(vs => vs.SeriesId == seriesId).ToList();
        }

        public VideoSeries GetVideoSeriesByVideoIdSeriesId(int videoId, int seriesId)
        {
            VideoSeries? videoSeries = _context.VideoSeries.Find(videoId, seriesId);
            return videoSeries == null ? throw new Exception("VideoSeries not found") : videoSeries;
        }

        public void AddVideoSeries(VideoSeries videoSeries)
        {
            _context.VideoSeries.Add(videoSeries);
            _context.SaveChanges();
        }

        public void DeleteVideoSeries(int id)
        {
            VideoSeries? videoSeries = _context.VideoSeries.Find(id);
            if (videoSeries != null)
            {
                _context.VideoSeries.Remove(videoSeries);
                _context.SaveChanges();
            }
        }

        public bool IsVideoSeriesExist(int videoId, int seriesId)
        {
            return _context.VideoSeries.Any(vs => vs.VideoId == videoId && vs.SeriesId == seriesId);
        }
    }
}
