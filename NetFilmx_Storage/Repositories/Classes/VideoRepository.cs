using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly NetFilmxDbContext _context;

        public VideoRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public List<Video> GetVideos()
        {
            return _context.Videos.ToList();
        }

        public Video GetVideoById(int id)
        {
            Video? video = _context.Videos.Find(id);
            return video == null ? throw new Exception("Video not found") : video;
        }

        public void AddVideo(Video video)
        {
            _context.Videos.Add(video);
            _context.SaveChanges();
        }

        public void EditVideo(Video video)
        {
            _context.Videos.Attach(video);
            _context.Entry(video).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteVideo(int id)
        {
            Video? video = _context.Videos.Find(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
                _context.SaveChanges();
            }
        }

        public bool IsVideoExist(int videoId)
        {
            return _context.Videos.Any(v => v.Id == videoId);
        }
    }
}
