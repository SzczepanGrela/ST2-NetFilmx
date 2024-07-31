using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentsAsync();
        Task<List<Comment>> GetCommentsByVideoIdAsync(int videoId);
        Task<List<Comment>> GetCommentsByUserIdAsync(int userId);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task AddCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(int commentId);

        Task<bool> IsCommentExistAsync(int commentId);
    }
}
