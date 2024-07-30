using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetAllComments();
        List<Comment> GetCommentsByVideoId(int videoId);
        List<Comment> GetCommentsByUserId(int userId);
        Comment GetCommentById(int commentId);
        void AddComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int commentId);

        bool IsCommentExist(int commentId);
    }
}
