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
            if(!_context.Categories.Any(c => c.Id == categoryId))
            {
                throw new Exception("Category not found");
            }
            return _context.Categories.Include(c => c.Videos).Where(c => c.Id == categoryId).SelectMany(c => c.Videos).ToList();
        }

        public List<Video> GetVideosByTagId(int tagId)
        {
            if(!_context.Tags.Any(t => t.Id == tagId))
            {
                throw new Exception("Tag not found");
            }
            return _context.Tags.Include(t => t.Videos).Where(t => t.Id == tagId).SelectMany(t => t.Videos).ToList();
        }

        public List<Video> GetVideosBySeriesId(int seriesId)
        {
            if(!_context.Series.Any(s => s.Id == seriesId))
            {
                throw new Exception("Series not found");
            }
            return _context.Series.Include(s => s.Videos).Where(s => s.Id == seriesId).SelectMany(s => s.Videos).ToList();
        }

        public List<Video> GetVideosByUserId(int userId)
        {
            if(!_context.Users.Any(u => u.Id == userId))
            {
                throw new Exception("User not found");
            }
            return _context.Videos.Include(v => v.VideoPurchases).Where(v => v.VideoPurchases.Any(vp => vp.UserId == userId)).ToList();
        }

        public Video GetVideoByVideoPurchaseId(int videoPurchaseId)
        {
            if(!_context.VideoPurchases.Any(vp => vp.Id == videoPurchaseId))
            {
                throw new Exception("Video purchase not found");
            }
            var video = _context.Videos.Include(v => v.VideoPurchases).Where(v => v.VideoPurchases.Any(vp => vp.Id == videoPurchaseId)).FirstOrDefault();
            return video == null ? throw new Exception("Video not found") : video;
        }

        public Video GetVideoByCommentId(int commentId)
        {
            if(!_context.Comments.Any(c => c.Id == commentId))
            {
                throw new Exception("Comment not found");
            }
            var video = _context.Videos.Include(v => v.Comments).Where(v => v.Comments.Any(c => c.Id == commentId)).FirstOrDefault();
            return video == null ? throw new Exception("Video not found") : video;
        }

        public Video GetVideoByLikeId(int likeId)
        {
            if(!_context.Likes.Any(l => l.Id == likeId))
            {
                throw new Exception("Like not found");
            }
            var video = _context.Videos.Include(v => v.Likes).Where(v => v.Likes.Any(l => l.Id == likeId)).FirstOrDefault();
            return video == null ? throw new Exception("Video not found") : video;
        }



        public Video GetVideoById(int videoId)
        {
            var video = _context.Videos.Find(videoId);
            return video == null ? throw new Exception("Video not found") : video;
        }

        public void AddVideo(Video video)
        {
            if (video == null)
            {
                throw new ArgumentNullException(nameof(video), "Video cannot be null");
            }
            _context.Videos.Add(video);
            _context.SaveChanges();
        }

        public void UpdateVideo(Video video)
        {

            if(video == null)
            {
                throw new ArgumentNullException(nameof(video), "Video cannot be null");
            }
            if (!IsVideoExist(video.Id))
            {
                throw new Exception("Video not found");
            }

            _context.Videos.Attach(video);
            _context.Entry(video).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteVideo(int videoId)
        {
            var video = _context.Videos.Find(videoId);
            if (video != null)
            {
                _context.Videos.Remove(video);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Video not found");
            }
        }

        public void AddVideoToSeries(int videoId, int seriesId)
        {
            var video = _context.Videos.Find(videoId);
            var series = _context.Series.Find(seriesId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (series == null)
            {
                throw new Exception("Series not found");
            }

            if (video.Series.Contains(series))
            {
                throw new Exception("The video is already part of the series");
            }

            video.Series.Add(series);
            _context.SaveChanges();
        }

        public void AddVideoToCategory(int videoId, int categoryId)
        {
            var video = _context.Videos.Find(videoId);
            var category = _context.Categories.Find(categoryId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            if (video.Categories.Contains(category))
            {
                throw new Exception("The video is already part of the category");
            }

            video.Categories.Add(category);
            _context.SaveChanges();
        }


        public void AddVideoToTag(int videoId, int tagId)
        {
            var video = _context.Videos.Find(videoId);
            var tag = _context.Tags.Find(tagId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (tag == null)
            {
                throw new Exception("Tag not found");
            }

            if (video.Tags.Contains(tag))
            {
                throw new Exception("The video is already part of the tag");
            }

            video.Tags.Add(tag);
            _context.SaveChanges();
        }

        public void RemoveVideoFromSeries(int videoId, int seriesId)
        {
            var video = _context.Videos.Find(videoId);
            var series = _context.Series.Find(seriesId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (series == null)
            {
                throw new Exception("Series not found");
            }

            if (!video.Series.Contains(series))
            {
                throw new Exception("The video is not part of the series");
            }

            video.Series.Remove(series);
            _context.SaveChanges();
        }

        public void RemoveVideoFromCategory(int videoId, int categoryId)
        {
            var video = _context.Videos.Find(videoId);
            var category = _context.Categories.Find(categoryId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            if (!video.Categories.Contains(category))
            {
                throw new Exception("The video is not part of the category");
            }

            video.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void RemoveVideoFromTag(int videoId, int tagId)
        {
            var video = _context.Videos.Find(videoId);
            var tag = _context.Tags.Find(tagId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (tag == null)
            {
                throw new Exception("Tag not found");
            }

            if (!video.Tags.Contains(tag))
            {
                throw new Exception("The video is not part of the tag");
            }

            video.Tags.Remove(tag);
            _context.SaveChanges();
        }




        public bool IsVideoExist(int videoId)
        {
            return _context.Videos.Any(v => v.Id == videoId);
        }

        public bool IsVideoExistInTag(int tagId, int videoId)
        {
            if(!_context.Tags.Any(t => t.Id == tagId))
            {
                throw new Exception("Tag not found");
            }
            if(!_context.Videos.Any(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }
            return _context.Tags.Include(t => t.Videos).Any(t => t.Id == tagId && t.Videos.Any(v => v.Id == videoId));
        }

        public bool IsVideoExistInSeries(int seriesId, int videoId)
        {
            if(!_context.Series.Any(s => s.Id == seriesId))
            {
                throw new Exception("Series not found");
            }
            if(!_context.Videos.Any(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }
            return _context.Series.Include(s => s.Videos).Any(s => s.Id == seriesId && s.Videos.Any(v => v.Id == videoId));
        }

        public bool IsVideoExistInCategory(int categoryId, int videoId)
        {
            if(!_context.Categories.Any(c => c.Id == categoryId))
            {
                throw new Exception("Category not found");
            }
            if(!_context.Videos.Any(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }
            return _context.Categories.Include(c => c.Videos).Any(c => c.Id == categoryId && c.Videos.Any(v => v.Id == videoId));
        }

    }
}
