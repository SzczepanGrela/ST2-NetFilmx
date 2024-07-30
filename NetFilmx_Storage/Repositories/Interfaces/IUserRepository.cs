using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        List<User> GetUsersByVideoId(int videoId);
        List<User> GetUsersBySeriesId(int seriesId);

        User GetUserByUsername(string username);
        User GetUserById(int userId);
        User GetUserByCommentId(int commentId);
        User GetUserByLikeId(int likeId);
        User GetUserByVideoPurchaseId(int videoPurchaseId);
        User GetUserBySeriesPurchaseId(int seriesPurchaseId);

        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);

        bool IsUserExist(string username);
        bool IsUserExist(int userId);
    }
}
