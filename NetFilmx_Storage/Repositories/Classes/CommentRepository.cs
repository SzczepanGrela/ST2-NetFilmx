using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Comment> _dbSet;

        public CommentRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Comment>();
        }

        public List<Comment> GetCommentsByVideoId(int videoId)
        {
            return _dbSet.Where(c => c.VideoId == videoId).ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _dbSet.Find(id);
        }

        public void AddComment(Comment comment)
        {
            _dbSet.Add(comment);
            _context.SaveChanges();
        }

        public void EditComment(Comment comment)
        {
            _dbSet.Attach(comment);
            _context.Entry(comment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            Comment comment = _dbSet.Find(id);
            if (comment != null)
            {
                _dbSet.Remove(comment);
                _context.SaveChanges();
            }
        }
    }
}
