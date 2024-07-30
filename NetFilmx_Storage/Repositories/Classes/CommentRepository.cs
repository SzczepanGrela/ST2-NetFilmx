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

        public List<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        public List<Comment> GetCommentsByVideoId(int videoId)
        {
            if(!_context.Videos.Any(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }
            return _context.Comments.Where(c => c.VideoId == videoId).ToList();
        }
        
        public List<Comment> GetCommentsByUserId(int userId)
        {
            if(!_context.Users.Any(u => u.Id == userId))
            {
                throw new Exception("User not found");
            }
            return _context.Comments.Where(c => c.UserId == userId).ToList();
        }

        public Comment GetCommentById(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                throw new Exception("Comment not found");
            }
            return comment;
        }

        public void AddComment(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment), "Comment cannot be null");
            }
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment), "Comment cannot be null");
            }
            if (!IsCommentExist(comment.Id))
            {
                throw new Exception("Comment not found");
            }
            _context.Comments.Attach(comment);
            _context.Entry(comment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = GetCommentById(id);
            if (comment == null)
            {
                throw new Exception("Comment not found");
            }
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public bool IsCommentExist(int commentId)
        {
            return _context.Comments.Any(c => c.Id == commentId);
        }
    }
}
