using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NetFilmxDbContext _context;

        public UserRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public List<User> GetUserByUsername()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            User? user = _context.Users.Find(id);

            return user == null ? throw new Exception("User not found") : user;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void EditUser(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User? user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public bool IsUserExist(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }
    }
}
