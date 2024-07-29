using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class VideoCategoryRepository : IVideoCategoryRepository
    {
        private readonly NetFilmxDbContext _context;

        public VideoCategoryRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public List<VideoCategory> GetVideoCategoriesByVideoId(int videoId)
        {
            return _context.VideoCategories.Where(vc => vc.VideoId == videoId).ToList();
        }

        public VideoCategory GetVideoCategoryByVideoIdCategoryId(int videoId, int categoryId)
        {
            VideoCategory? videoCategory = _context.VideoCategories.Find(videoId, categoryId);
            return videoCategory == null ? throw new Exception("VideoCategory not found") : videoCategory;
        }

        public void AddVideoCategory(VideoCategory videoCategory)
        {
            _context.VideoCategories.Add(videoCategory);
            _context.SaveChanges();
        }

        public void DeleteVideoCategory(int id)
        {
            VideoCategory? videoCategory = _context.VideoCategories.Find(id);
            if (videoCategory != null)
            {
                _context.VideoCategories.Remove(videoCategory);
                _context.SaveChanges();
            }
        }

        public bool IsVideoCategoryExist(int videoId, int categoryId)
        {
            return _context.VideoCategories.Any(vc => vc.VideoId == videoId && vc.CategoryId == categoryId);
        }
    }
}
