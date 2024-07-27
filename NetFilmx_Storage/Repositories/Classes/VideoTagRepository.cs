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

        public List<VideoTag> GetVideoTagsByVideoId(int videoId)
        {
            return _dbSet.Where(vt => vt.VideoId == videoId).ToList();
        }

        public void AddVideoTag(VideoTag videoTag)
        {
            _dbSet.Add(videoTag);
            _context.SaveChanges();
        }

        public void DeleteVideoTag(int id)
        {
            VideoTag videoTag = _dbSet.Find(id);
            if (videoTag != null)
            {
                _dbSet.Remove(videoTag);
                _context.SaveChanges();
            }
        }

        public bool IsVideoTagExist(int video_Id, int tag_Id)
        {
           return _dbSet.Any(vt => vt.VideoId == video_Id && vt.TagId == tag_Id);
        }
    }
}
