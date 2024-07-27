using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUserByUsername();
        User GetUserById(int id);
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(int id);
        bool IsUserExist(string username);
    }
}
