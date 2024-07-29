using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class VideoTagRepository : IVideoTagRepository
    {
        private readonly NetFilmxDbContext _context;

        public VideoTagRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public List<VideoTag> GetVideoTagsByVideoId(int videoId)
        {
            return _context.VideoTags.Where(vt => vt.VideoId == videoId).ToList();
        }

        public VideoTag GetVideoTagByVideoIdTagId(int videoId, int tagId)
        {
            VideoTag? videoTag = _context.VideoTags.Find(videoId, tagId);
            return videoTag == null ? throw new Exception("VideoTag not found") : videoTag;
        }

        public void AddVideoTag(VideoTag videoTag)
        {
            _context.VideoTags.Add(videoTag);
            _context.SaveChanges();
        }

        public void DeleteVideoTag(int id)
        {
            VideoTag? videoTag = _context.VideoTags.Find(id);
            if (videoTag != null)
            {
                _context.VideoTags.Remove(videoTag);
                _context.SaveChanges();
            }
        }

        public bool IsVideoTagExist(int videoId, int tagId)
        {
            return _context.VideoTags.Any(vt => vt.VideoId == videoId && vt.TagId == tagId);
        }
    }
}
