using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public class VideoPurchaseRepository : IVideoPurchaseRepository
    {
        private readonly NetFilmxDbContext _context;


        public List<VideoPurchase> GetVideoPurchasesByUserId(int userId)
        {
            return _context.VideoPurchases.Where(vp => vp.UserId == userId).ToList();
        }

        public List<VideoPurchase> GetVideoPurchasesByVideoId(int videoId)
        {
            return _context.VideoPurchases.Where(vp => vp.VideoId == videoId).ToList();
        }

        public List<VideoPurchase> GetAllVideoPurchases()
        {
            return _context.VideoPurchases.ToList();
        }

    
        public VideoPurchase GetVideoPurchaseById(int videoPurchaseId)
        {
            var videoPurchase = _context.VideoPurchases.Find(videoPurchaseId);
            return videoPurchase == null ? throw new Exception("Video purchase not found") : videoPurchase;
        }



        public bool IsVideoPurchaseExist(int userId, int videoId)
        {
            if(!_context.Users.Any(u => u.Id == userId))
            {
                throw new Exception("User not found");
            }
            if(!_context.Videos.Any(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }
            return _context.VideoPurchases.Any(vp => vp.UserId == userId && vp.VideoId == videoId);
        }

        public bool IsVideoPurchaseExist(int videoPurchaseId)
        {
            return _context.VideoPurchases.Any(vp => vp.Id == videoPurchaseId);
        }

        public void UpdateVideoPurchase(VideoPurchase videoPurchase)
        {
            if (videoPurchase == null)
            {
                throw new ArgumentNullException(nameof(videoPurchase), "Video purchase cannot be null");
            }

            if (!IsVideoPurchaseExist(videoPurchase.Id))
            {
                throw new Exception("Video purchase not found");
            }

            _context.VideoPurchases.Attach(videoPurchase);
            _context.Entry(videoPurchase).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }


        public void AddVideoPurchase(VideoPurchase videoPurchase)
        {
            if (videoPurchase == null)
            {
                throw new ArgumentNullException(nameof(videoPurchase), "Video purchase cannot be null");
            }

            if (IsVideoPurchaseExist(videoPurchase.UserId, videoPurchase.VideoId))
            {
                throw new InvalidOperationException("The video purchase already exists");
            }

            _context.VideoPurchases.Add(videoPurchase);
            _context.SaveChanges();
        }

        public void DeleteVideoPurchase(int videoPurchaseId)
        {
            var videoPurchase = GetVideoPurchaseById(videoPurchaseId);
            if (videoPurchase == null)
            {
                throw new Exception("Video purchase not found");
            }

            _context.VideoPurchases.Remove(videoPurchase);
            _context.SaveChanges();
        }

    }

}
