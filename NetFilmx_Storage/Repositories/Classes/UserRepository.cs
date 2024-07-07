using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public List<User> GetUsers()
        {
            return _dbSet.ToList();
        }

        public User GetUserById(long id)
        {
            return _dbSet.Find(id);
        }

        public void AddUser(User user)
        {
            _dbSet.Add(user);
            _context.SaveChanges();
        }

        public void EditUser(User user)
        {
            _dbSet.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveUser(long id)
        {
            User user = _dbSet.Find(id);
            if (user != null)
            {
                _dbSet.Remove(user);
                _context.SaveChanges();
            }
        }

        public bool IsUserExist(long userId)
        {
            return _dbSet.Any(u => u.Id == userId);
        }

        public bool IsUserExist(string username)
        {
            return _dbSet.Any(u => u.Username == username);
        }
    }
}
