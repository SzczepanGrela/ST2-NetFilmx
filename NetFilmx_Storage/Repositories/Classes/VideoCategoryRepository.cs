using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class VideoCategoryRepository : IVideoCategoryRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<VideoCategory> _dbSet;

        public VideoCategoryRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<VideoCategory>();
        }

        public List<VideoCategory> GetVideoCategoriesByVideoId(long videoId)
        {
            return _dbSet.Where(vc => vc.VideoId == videoId).ToList();
        }

        public void AddVideoCategory(VideoCategory videoCategory)
        {
            _dbSet.Add(videoCategory);
            _context.SaveChanges();
        }

        public void RemoveVideoCategory(long id)
        {
            VideoCategory videoCategory = _dbSet.Find(id);
            if (videoCategory != null)
            {
                _dbSet.Remove(videoCategory);
                _context.SaveChanges();
            }
        }
    }
}
