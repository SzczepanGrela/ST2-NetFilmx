using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public class VideoPurchaseRepository : IVideoPurchaseRepository
    {
        private readonly NetFilmxDbContext _context;

        public VideoPurchaseRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public async Task AddVideoPurchaseAsync(VideoPurchase videoPurchase)
        {
            if (videoPurchase == null)
            {
                throw new ArgumentNullException(nameof(videoPurchase), "Video purchase cannot be null");
            }

            if (await IsVideoPurchaseExistAsync(videoPurchase.UserId, videoPurchase.VideoId))
            {
                throw new InvalidOperationException("The video purchase already exists");
            }

            await _context.VideoPurchases.AddAsync(videoPurchase);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVideoPurchaseAsync(VideoPurchase videoPurchase)
        {
            if (videoPurchase == null)
            {
                throw new ArgumentNullException(nameof(videoPurchase), "Video purchase cannot be null");
            }

            if (!await IsVideoPurchaseExistAsync(videoPurchase.Id))
            {
                throw new Exception("Video purchase not found");
            }

            _context.VideoPurchases.Attach(videoPurchase);
            _context.Entry(videoPurchase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVideoPurchaseAsync(int videoId, int userId)
        {   
            var videoPurchase = await _context.VideoPurchases.FirstOrDefaultAsync(vp => vp.UserId == userId && vp.VideoId == videoId);

            if (videoPurchase == null)
            {
                throw new Exception("Video purchase not found");
            }

            _context.VideoPurchases.Remove(videoPurchase);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsVideoPurchaseExistAsync(int videoPurchaseId)
        {
            return await _context.VideoPurchases.AnyAsync(vp => vp.Id == videoPurchaseId);
        }

        public async Task<bool> IsVideoPurchaseExistAsync(int userId, int videoId)
        {
            if (!await _context.Users.AnyAsync(u => u.Id == userId))
            {
                throw new Exception("User not found");
            }

            if (!await _context.Videos.AnyAsync(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }

            return await _context.VideoPurchases.AnyAsync(vp => vp.UserId == userId && vp.VideoId == videoId);
        }


        public async Task<List<VideoPurchase>> GetAllVideoPurchasesAsync()
        {
            return await _context.VideoPurchases.ToListAsync();
        }


        public async Task<VideoPurchase> GetVideoPurchaseByIdAsync(int videoPurchaseId)
        {
            var videoPurchase = await _context.VideoPurchases.FindAsync(videoPurchaseId);
            return videoPurchase ?? throw new Exception("Video purchase not found");

        }


        public async Task<VideoPurchase> GetVideoPurchaseByUserAndVideoIdAsync(int userId, int videoId)
        {
            var videoPurchase = await _context.VideoPurchases.FirstOrDefaultAsync(vp => vp.UserId == userId && vp.VideoId == videoId);
            return videoPurchase ?? throw new Exception("Video purchase not found");
        }

        public async Task<List<VideoPurchase>> GetVideoPurchasesByUserIdAsync(int userId)
        {
            if (!await _context.Users.AnyAsync(u => u.Id == userId))
            {
                throw new Exception("User not found");
            }

            return await _context.VideoPurchases.Where(vp => vp.UserId == userId).ToListAsync();
        }

        public async Task<List<VideoPurchase>> GetVideoPurchasesByVideoIdAsync(int videoId)
        {
            if (!await _context.Videos.AnyAsync(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }

            return await _context.VideoPurchases.Where(vp => vp.VideoId == videoId).ToListAsync();
        }

        public async Task<VideoPurchase> GetVideoPurchaseByUserIdVideoIdAsync(int userId, int videoId)
        {
            var videoPurchase = await _context.VideoPurchases.FirstOrDefaultAsync(vp => vp.UserId == userId && vp.VideoId == videoId);
            return videoPurchase ?? throw new Exception("Video purchase not found");
        }


    }
}
