using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly NetFilmxDbContext _context;

        public LikeRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetLikesCountByVideoIdAsync(int videoId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            if (video == null)
            {
                throw new Exception("Video not found");
            }
            return await _context.Likes.CountAsync(l => l.VideoId == videoId);
        }

        public async Task AddLikeAsync(Like like)
        {
            if (like == null)
            {
                throw new ArgumentNullException(nameof(like), "Like cannot be null");
            }
            if (await IsLikeExistAsync(like.VideoId, like.UserId))
            {
                throw new InvalidOperationException("The like already exists");
            }
            if (!await _context.Videos.AnyAsync(v => v.Id == like.VideoId))
            {
                throw new Exception("Video not found");
            }
            if (!await _context.Users.AnyAsync(u => u.Id == like.UserId))
            {
                throw new Exception("User not found");
            }
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLikeAsync(int id)
        {
            var like = await _context.Likes.FindAsync(id);
            if (like == null)
            {
                throw new Exception("Like not found");
            }
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsLikeExistAsync(int video_Id, int user_Id)
        {
            if (!await _context.Videos.AnyAsync(v => v.Id == video_Id))
            {
                throw new Exception("Video not found");
            }
            if (!await _context.Users.AnyAsync(u => u.Id == user_Id))
            {
                throw new Exception("User not found");
            }
            return await _context.Likes.AnyAsync(l => l.VideoId == video_Id && l.UserId == user_Id);
        }
    }
}
