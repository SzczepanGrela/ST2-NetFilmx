using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Video> _dbSet;

        public VideoRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Video>();
        }

        public List<Video> GetVideos()
        {
            return _dbSet.ToList();
        }

        public Video GetVideoById(int id)
        {
            return _dbSet.Find(id);
        }

        public void AddVideo(Video video)
        {
            _dbSet.Add(video);
            _context.SaveChanges();
        }

        public void EditVideo(Video video)
        {
            _dbSet.Attach(video);
            _context.Entry(video).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteVideo(int id)
        {
            Video video = _dbSet.Find(id);
            if (video != null)
            {
                _dbSet.Remove(video);
                _context.SaveChanges();
            }
        }

        public bool IsVideoExist(int videoId)
        {
            return _dbSet.Any(v => v.Id == videoId);
        }
    }
}
