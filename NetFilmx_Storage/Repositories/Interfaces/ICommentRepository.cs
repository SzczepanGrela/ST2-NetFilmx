using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentsByVideoId(int videoId);
        Comment GetCommentById(int id);
        void AddComment(Comment comment);
        void EditComment(Comment comment);
        void DeleteComment(int id);
    }
}
