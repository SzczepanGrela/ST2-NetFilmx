using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<List<User>> GetUsersByVideoIdAsync(int videoId);
        Task<List<User>> GetUsersBySeriesIdAsync(int seriesId);

        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByCommentIdAsync(int commentId);
        Task<User> GetUserByLikeIdAsync(int likeId);
        Task<User> GetUserByVideoPurchaseIdAsync(int videoPurchaseId);
        Task<User> GetUserBySeriesPurchaseIdAsync(int seriesPurchaseId);

        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);

        Task<bool> IsUserExistAsync(string username);
        Task<bool> IsUserExistAsync(int userId);
    }
}
