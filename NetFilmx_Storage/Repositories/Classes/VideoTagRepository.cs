using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class VideoTagRepository : IVideoTagRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<VideoTag> _dbSet;

        public VideoTagRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<VideoTag>();
        }

        public List<VideoTag> GetVideoTagsByVideoId(long videoId)
        {
            return _dbSet.Where(vt => vt.VideoId == videoId).ToList();
        }

        public void AddVideoTag(VideoTag videoTag)
        {
            _dbSet.Add(videoTag);
            _context.SaveChanges();
        }

        public void RemoveVideoTag(long id)
        {
            VideoTag videoTag = _dbSet.Find(id);
            if (videoTag != null)
            {
                _dbSet.Remove(videoTag);
                _context.SaveChanges();
            }
        }
    }
}
