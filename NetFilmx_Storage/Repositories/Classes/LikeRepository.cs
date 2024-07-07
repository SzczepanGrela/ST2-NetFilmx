using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Like> _dbSet;

        public LikeRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Like>();
        }

        public List<Like> GetLikesByVideoId(long videoId)
        {
            return _dbSet.Where(l => l.VideoId == videoId).ToList();
        }

        public Like GetLikeById(long id)
        {
            return _dbSet.Find(id);
        }

        public void AddLike(Like like)
        {
            _dbSet.Add(like);
            _context.SaveChanges();
        }

        public void RemoveLike(long id)
        {
            Like like = _dbSet.Find(id);
            if (like != null)
            {
                _dbSet.Remove(like);
                _context.SaveChanges();
            }
        }
    }
}
