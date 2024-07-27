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

        public List<VideoCategory> GetVideoCategoriesByVideoId(int videoId)
        {
            return _dbSet.Where(vc => vc.VideoId == videoId).ToList();
        }

        public VideoCategory GetVideoCategoryByVideoIdCategoryId(int videoId, int categoryId)
        {
            var videoCategory = _dbSet.Find(videoId, categoryId);
            if (videoCategory == null)
            {
                throw new Exception("VideoCategory not found");
            }
            return videoCategory;
        }


        public void AddVideoCategory(VideoCategory videoCategory)
        {
            _dbSet.Add(videoCategory);
            _context.SaveChanges();
        }

        public void DeleteVideoCategory(int id)
        {
            VideoCategory? videoCategory = _dbSet.Find(id);
            if (videoCategory != null)
            {
                _dbSet.Remove(videoCategory);
                _context.SaveChanges();
            }
       
        }

        public bool IsVideoCategoryExist(int videoId, int categoryId)
        {
            return _dbSet.Any(vc => vc.VideoId == videoId && vc.CategoryId == categoryId);
        }


    }
}
