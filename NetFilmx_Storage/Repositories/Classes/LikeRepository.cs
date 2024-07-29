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
            return _context.Likes.Where(l => l.VideoId == videoId).ToList();
        }

        public Like GetLikeById(int id)
        {
            Like? like =  _context.Likes.Find(id);
            return like == null ? throw new Exception("Like not found") : like;
        }

        public void AddLike(Like like)
        {
            _context.Likes.Add(like);
            _context.SaveChanges();
        }

        public void DeleteLike(int id)
        {
            Like? like = _context.Likes.Find(id);
            if (like != null)
            {
                _context.Likes.Remove(like);
                _context.SaveChanges();
            }
        }

        public bool IsLikeExist(int video_Id, int user_Id)
        {
            return _context.Likes.Any(l => l.VideoId == video_Id && l.UserId == user_Id);
        }
    }
}
