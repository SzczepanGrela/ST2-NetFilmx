using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly NetFilmxDbContext _context;

        public LikeRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public List<Like> GetLikesByVideoId(int videoId)
        {
            var video = _context.Videos.Find(videoId);
            if (video == null)
            {
                throw new Exception("Video not found");
            }
            return _context.Likes.Where(l => l.VideoId == videoId).ToList();
        }

        public Like GetLikeById(int id)
        {
            var like = _context.Likes.Find(id);
            if (like == null)
            {
                throw new Exception("Like not found");
            }
            return like;
        }


        public int GetLikesCountByVideoId(int videoId)
        {
            var video = _context.Videos.Find(videoId);
            if (video == null)
            {
                throw new Exception("Video not found");
            }
            return _context.Likes.Count(l => l.VideoId == videoId);
        }


        public void AddLike(Like like)
        {
            if (like == null)
            {
                throw new ArgumentNullException(nameof(like), "Like cannot be null");
            }
            if (IsLikeExist(like.VideoId, like.UserId))
            {
                throw new InvalidOperationException("The like already exists");
            }
            if (!_context.Videos.Any(v => v.Id == like.VideoId))
            {
                throw new Exception("Video not found");
            }
            if (!_context.Users.Any(u => u.Id == like.UserId))
            {
                throw new Exception("User not found");
            }
            _context.Likes.Add(like);
            _context.SaveChanges();
        }

        public void DeleteLike(int id)
        {
            var like = GetLikeById(id);
            if (like == null)
            {
                throw new Exception("Like not found");
            }
            _context.Likes.Remove(like);
            _context.SaveChanges();
        }

        public bool IsLikeExist(int video_Id, int user_Id)
        {
            if(!_context.Videos.Any(v => v.Id == video_Id))
            {
                throw new Exception("Video not found");
            }
            if (!_context.Users.Any(u => u.Id == user_Id))
            {
                throw new Exception("User not found");
            }
            return _context.Likes.Any(l => l.VideoId == video_Id && l.UserId == user_Id);
        }
    }
}
