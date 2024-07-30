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

        public void AddVideoPurchase(VideoPurchase videoPurchase)
        {
            _context.VideoPurchases.Add(videoPurchase);
            _context.SaveChanges();
        }

        public void DeleteVideoPurchase(int videoPurchaseId)
        {
            _context.VideoPurchases.Remove(GetVideoPurchaseById(videoPurchaseId));
            _context.SaveChanges();
        }

        public List<VideoPurchase> GetAllVideoPurchases()
        {
            return _context.VideoPurchases.ToList();
        }

        public VideoPurchase GetVideoPurchaseById(int videoPurchaseId)
        {
            return _context.VideoPurchases.Find(videoPurchaseId) ?? throw new Exception("Video purchase not found");
        }

        public List<VideoPurchase> GetVideoPurchasesByUserId(int userId)
        {
            return _context.VideoPurchases.Where(vp => vp.UserId == userId).ToList();
        }

        public List<VideoPurchase> GetVideoPurchasesByVideoId(int videoId)
        {
            return _context.VideoPurchases.Where(vp => vp.VideoId == videoId).ToList();
        }

        public bool IsVideoPurchaseExist(int userId, int videoId)
        {
            return _context.VideoPurchases.Any(vp => vp.UserId == userId && vp.VideoId == videoId);
        }

        public bool IsVideoPurchaseExist(int videoPurchaseId)
        {
            return _context.VideoPurchases.Any(vp => vp.Id == videoPurchaseId);
        }

        public void UpdateVideoPurchase(VideoPurchase videoPurchase)
        {
            _context.VideoPurchases.Attach(videoPurchase);
            _context.Entry(videoPurchase).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }

}
