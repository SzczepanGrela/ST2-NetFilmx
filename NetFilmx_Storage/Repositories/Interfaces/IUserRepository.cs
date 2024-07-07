using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserById(long id);
        void AddUser(User user);
        void EditUser(User user);
        void RemoveUser(long id);
        bool IsUserExist(long userId);
        bool IsUserExist(string username);
    }
}
