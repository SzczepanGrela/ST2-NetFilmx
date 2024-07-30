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

        public List<Video> GetAllVideos()
        {
            return _context.Videos.ToList();
        }

        public List<Video> GetVideosByCategoryId(int categoryId)
        {
            return _context.Categories.Include(c => c.Videos).Where(c => c.Id == categoryId).SelectMany(c => c.Videos).ToList();
        }

        public List<Video> GetVideosByTagId(int tagId)
        {
            return _context.Tags.Include(t => t.Videos).Where(t => t.Id == tagId).SelectMany(t => t.Videos).ToList();
        }

        public List<Video> GetVideosBySeriesId(int seriesId)
        {
            return _context.Series.Include(s => s.Videos).Where(s => s.Id == seriesId).SelectMany(s => s.Videos).ToList();
        }

        public List<Video> GetVideosByUserId(int userId)
        {
            return _context.Videos.Include(v => v.VideoPurchases).Where(v => v.VideoPurchases.Any(vp => vp.UserId == userId)).ToList();
        }

        public Video GetVideoByVideoPurchaseId(int videoPurchaseId)
        {
            return _context.Videos.Include(v => v.VideoPurchases).Where(v => v.VideoPurchases.Any(vp => vp.Id == videoPurchaseId)).FirstOrDefault();
        }

        public Video GetVideoByCommentId(int commentId)
        {
            return _context.Videos.Include(v => v.Comments).Where(v => v.Comments.Any(c => c.Id == commentId)).FirstOrDefault();
        }

        public Video GetVideoByLikeId(int likeId)
        {
            return _context.Videos.Include(v => v.Likes).Where(v => v.Likes.Any(l => l.Id == likeId)).FirstOrDefault();
        }



        public Video GetVideoById(int userId)
        {
            Video? video = _context.Videos.Find(userId);
            return video == null ? throw new Exception("Video not found") : video;
        }

        public void AddVideo(Video video)
        {
            _context.Videos.Add(video);
            _context.SaveChanges();
        }

        public void UpdateVideo(Video video)
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

        public void AddVideoToSeries(int videoId, int seriesId)
        {
            Video? video = _context.Videos.Find(videoId);
            Series? series = _context.Series.Find(seriesId);

            if (video != null && series != null)
            {
                video.Series.Add(series);
                _context.SaveChanges();
            }
        }

        public void AddVideoToCategory(int videoId, int categoryId)
        {
            Video? video = _context.Videos.Find(videoId);
            Category? category = _context.Categories.Find(categoryId);

            if (video != null && category != null)
            {
                video.Categories.Add(category);
                _context.SaveChanges();
            }
        }


        public void AddVideoToTag(int videoId, int tagId)
        {
            Video? video = _context.Videos.Find(videoId);
            Tag? tag = _context.Tags.Find(tagId);

            if (video != null && tag != null)
            {
                video.Tags.Add(tag);
                _context.SaveChanges();
            }
        }

        public void RemoveVideoFromSeries(int videoId, int seriesId)
        {
            Video? video = _context.Videos.Find(videoId);
            Series? series = _context.Series.Find(seriesId);

            if (video != null && series != null)
            {
                video.Series.Remove(series);
                _context.SaveChanges();
            }
        }

        public void RemoveVideoFromCategory(int videoId, int categoryId)
        {
            Video? video = _context.Videos.Find(videoId);
            Category? category = _context.Categories.Find(categoryId);

            if (video != null && category != null)
            {
                video.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public void RemoveVideoFromTag(int videoId, int tagId)
        {
            Video? video = _context.Videos.Find(videoId);
            Tag? tag = _context.Tags.Find(tagId);

            if (video != null && tag != null)
            {
                video.Tags.Remove(tag);
                _context.SaveChanges();
            }
        }




        public bool IsVideoExist(int videoId)
        {
            return _context.Videos.Any(v => v.Id == videoId);
        }

        public bool IsVideoExistInTag(int tagId, int videoId)
        {
            return _context.Tags.Include(t => t.Videos).Any(t => t.Id == tagId && t.Videos.Any(v => v.Id == videoId));
        }

        public bool IsVideoExistInSeries(int seriesId, int videoId)
        {
            return _context.Series.Include(s => s.Videos).Any(s => s.Id == seriesId && s.Videos.Any(v => v.Id == videoId));
        }

        public bool IsVideoExistInCategory(int categoryId, int videoId)
        {
            return _context.Categories.Include(c => c.Videos).Any(c => c.Id == categoryId && c.Videos.Any(v => v.Id == videoId));
        }

    }
}
