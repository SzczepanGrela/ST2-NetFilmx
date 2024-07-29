using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly NetFilmxDbContext _context;

        public CommentRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public List<Comment> GetCommentsByVideoId(int videoId)
        {
            return _context.Comments.Where(c => c.VideoId == videoId).ToList();
        }

        public Comment GetCommentById(int id)
        {
            Comment? comment = _context.Comments.Find(id);
            return comment == null ? throw new Exception("Comment not found") : comment;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void EditComment(Comment comment)
        {
            _context.Comments.Attach(comment);
            _context.Entry(comment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            Comment? comment = _context.Comments.Find(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }
    }
}
