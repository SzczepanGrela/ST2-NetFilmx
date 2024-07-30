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
            User? user = _context.Users.Find(userId);

            return user == null ? throw new Exception("User not found") : user;
        }

        public User GetUserByUsername(string username)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Username == username);

            return user == null ? throw new Exception("User not found") : user;
        }

        public User GetUserByCommentId(int commentId)
        {
            Comment? comment = _context.Comments.Find(commentId);

            return comment == null ? throw new Exception("Comment not found") : GetUserById(comment.UserId);
        }

        public User GetUserByLikeId(int likeId)
        {
            Like? like = _context.Likes.Find(likeId);

            return like == null ? throw new Exception("Like not found") : GetUserById(like.UserId);
        }

        public User GetUserByVideoPurchaseId(int videoPurchaseId)
        {
            VideoPurchase? videoPurchase = _context.VideoPurchases.Find(videoPurchaseId);

            return videoPurchase == null ? throw new Exception("Video purchase not found") : GetUserById(videoPurchase.UserId);
        }

        public User GetUserBySeriesPurchaseId(int seriesPurchaseId)
        {
            SeriesPurchase? seriesPurchase = _context.SeriesPurchases.Find(seriesPurchaseId);

            return seriesPurchase == null ? throw new Exception("Series purchase not found") : GetUserById(seriesPurchase.UserId);
        }





        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            User? user = _context.Users.Find(userId);
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

        public bool IsUserExist(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }
    }
}
