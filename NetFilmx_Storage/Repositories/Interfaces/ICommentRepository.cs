using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentsByVideoId(long videoId);
        Comment GetCommentById(long id);
        void AddComment(Comment comment);
        void EditComment(Comment comment);
        void RemoveComment(long id);
    }
}
