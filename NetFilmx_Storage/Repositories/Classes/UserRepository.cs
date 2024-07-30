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

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }


        public List<User> GetUsersByVideoId(int videoId)
        {
            return _context.Users.Include(u => u.VideoPurchases).Where(u => u.VideoPurchases.Any(vp => vp.VideoId == videoId)).ToList();
        }

        public List<User> GetUsersBySeriesId(int seriesId)
        {
            return _context.Users.Include(u => u.SeriesPurchases).Where(u => u.SeriesPurchases.Any(sp => sp.SeriesId == seriesId)).ToList();
        }

        public User GetUserById(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public User GetUserByCommentId(int commentId)
        {
            var comment = _context.Comments.Find(commentId);
            if (comment == null)
            {
                throw new Exception("Comment not found");
            }
            return GetUserById(comment.UserId);
        }

        public User GetUserByLikeId(int likeId)
        {
            var like = _context.Likes.Find(likeId);
            if (like == null)
            {
                throw new Exception("Like not found");
            }
            return GetUserById(like.UserId);
        }

        public User GetUserByVideoPurchaseId(int videoPurchaseId)
        {
            var videoPurchase = _context.VideoPurchases.Find(videoPurchaseId);
            if (videoPurchase == null)
            {
                throw new Exception("Video purchase not found");
            }
            return GetUserById(videoPurchase.UserId);
        }

        public User GetUserBySeriesPurchaseId(int seriesPurchaseId)
        {
            var seriesPurchase = _context.SeriesPurchases.Find(seriesPurchaseId);
            if (seriesPurchase == null)
            {
                throw new Exception("Series purchase not found");
            }
            return GetUserById(seriesPurchase.UserId);
        }


        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            if (IsUserExist(user.Username))
            {
                throw new InvalidOperationException("A user with this username already exists");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            if (!IsUserExist(user.Id))
            {
                throw new Exception("User not found");
            }
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public bool IsUserExist(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public bool IsUserExist(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }
    }
}
