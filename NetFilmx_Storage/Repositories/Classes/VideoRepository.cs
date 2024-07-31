using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly NetFilmxDbContext _context;

        public VideoRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public async Task<List<Video>> GetAllVideosAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<List<Video>> GetVideosByCategoryIdAsync(int categoryId)
        {
            if (!await _context.Categories.AnyAsync(c => c.Id == categoryId))
            {
                throw new Exception("Category not found");
            }
            return await _context.Categories.Include(c => c.Videos).Where(c => c.Id == categoryId).SelectMany(c => c.Videos).ToListAsync();
        }

        public async Task<List<Video>> GetVideosByTagIdAsync(int tagId)
        {
            if (!await _context.Tags.AnyAsync(t => t.Id == tagId))
            {
                throw new Exception("Tag not found");
            }
            return await _context.Tags.Include(t => t.Videos).Where(t => t.Id == tagId).SelectMany(t => t.Videos).ToListAsync();
        }

        public async Task<List<Video>> GetVideosBySeriesIdAsync(int seriesId)
        {
            if (!await _context.Series.AnyAsync(s => s.Id == seriesId))
            {
                throw new Exception("Series not found");
            }
            return await _context.Series.Include(s => s.Videos).Where(s => s.Id == seriesId).SelectMany(s => s.Videos).ToListAsync();
        }

        public async Task<List<Video>> GetVideosByUserIdAsync(int userId)
        {
            if (!await _context.Users.AnyAsync(u => u.Id == userId))
            {
                throw new Exception("User not found");
            }
            return await _context.Videos.Include(v => v.VideoPurchases).Where(v => v.VideoPurchases.Any(vp => vp.UserId == userId)).ToListAsync();
        }

        public async Task<Video> GetVideoByVideoPurchaseIdAsync(int videoPurchaseId)
        {
            if (!await _context.VideoPurchases.AnyAsync(vp => vp.Id == videoPurchaseId))
            {
                throw new Exception("Video purchase not found");
            }
            var video = await _context.Videos.Include(v => v.VideoPurchases).Where(v => v.VideoPurchases.Any(vp => vp.Id == videoPurchaseId)).FirstOrDefaultAsync();
            return video ?? throw new Exception("Video not found");
        }

        public async Task<Video> GetVideoByCommentIdAsync(int commentId)
        {
            if (!await _context.Comments.AnyAsync(c => c.Id == commentId))
            {
                throw new Exception("Comment not found");
            }
            var video = await _context.Videos.Include(v => v.Comments).Where(v => v.Comments.Any(c => c.Id == commentId)).FirstOrDefaultAsync();
            return video ?? throw new Exception("Video not found");
        }

        public async Task<Video> GetVideoByLikeIdAsync(int likeId)
        {
            if (!await _context.Likes.AnyAsync(l => l.Id == likeId))
            {
                throw new Exception("Like not found");
            }
            var video = await _context.Videos.Include(v => v.Likes).Where(v => v.Likes.Any(l => l.Id == likeId)).FirstOrDefaultAsync();
            return video ?? throw new Exception("Video not found");
        }

        public async Task<Video> GetVideoByIdAsync(int videoId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            return video ?? throw new Exception("Video not found");
        }

        public async Task AddVideoAsync(Video video)
        {
            if (video == null)
            {
                throw new ArgumentNullException(nameof(video), "Video cannot be null");
            }
            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVideoAsync(Video video)
        {
            if (video == null)
            {
                throw new ArgumentNullException(nameof(video), "Video cannot be null");
            }
            if (!await IsVideoExistAsync(video.Id))
            {
                throw new Exception("Video not found");
            }

            _context.Videos.Attach(video);
            _context.Entry(video).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVideoAsync(int videoId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            if (video == null)
            {
                throw new Exception("Video not found");
            }
            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
        }

        public async Task AddVideoToSeriesAsync(int videoId, int seriesId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            var series = await _context.Series.FindAsync(seriesId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (series == null)
            {
                throw new Exception("Series not found");
            }

            if (video.Series.Contains(series))
            {
                throw new Exception("The video is already part of the series");
            }

            video.Series.Add(series);
            await _context.SaveChangesAsync();
        }

        public async Task AddVideoToCategoryAsync(int videoId, int categoryId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            var category = await _context.Categories.FindAsync(categoryId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            if (video.Categories.Contains(category))
            {
                throw new Exception("The video is already part of the category");
            }

            video.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task AddVideoToTagAsync(int videoId, int tagId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            var tag = await _context.Tags.FindAsync(tagId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (tag == null)
            {
                throw new Exception("Tag not found");
            }

            if (video.Tags.Contains(tag))
            {
                throw new Exception("The video is already part of the tag");
            }

            video.Tags.Add(tag);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveVideoFromSeriesAsync(int videoId, int seriesId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            var series = await _context.Series.FindAsync(seriesId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (series == null)
            {
                throw new Exception("Series not found");
            }

            if (!video.Series.Contains(series))
            {
                throw new Exception("The video is not part of the series");
            }

            video.Series.Remove(series);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveVideoFromCategoryAsync(int videoId, int categoryId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            var category = await _context.Categories.FindAsync(categoryId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            if (!video.Categories.Contains(category))
            {
                throw new Exception("The video is not part of the category");
            }

            video.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveVideoFromTagAsync(int videoId, int tagId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            var tag = await _context.Tags.FindAsync(tagId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            if (tag == null)
            {
                throw new Exception("Tag not found");
            }

            if (!video.Tags.Contains(tag))
            {
                throw new Exception("The video is not part of the tag");
            }

            video.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsVideoExistAsync(int videoId)
        {
            return await _context.Videos.AnyAsync(v => v.Id == videoId);
        }

        public async Task<bool> IsVideoExistInTagAsync(int tagId, int videoId)
        {
            if (!await _context.Tags.AnyAsync(t => t.Id == tagId))
            {
                throw new Exception("Tag not found");
            }
            if (!await _context.Videos.AnyAsync(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }
            return await _context.Tags.Include(t => t.Videos).AnyAsync(t => t.Id == tagId && t.Videos.Any(v => v.Id == videoId));
        }

        public async Task<bool> IsVideoExistInSeriesAsync(int seriesId, int videoId)
        {
            if (!await _context.Series.AnyAsync(s => s.Id == seriesId))
            {
                throw new Exception("Series not found");
            }
            if (!await _context.Videos.AnyAsync(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }
            return await _context.Series.Include(s => s.Videos).AnyAsync(s => s.Id == seriesId && s.Videos.Any(v => v.Id == videoId));
        }

        public async Task<bool> IsVideoExistInCategoryAsync(int categoryId, int videoId)
        {
            if (!await _context.Categories.AnyAsync(c => c.Id == categoryId))
            {
                throw new Exception("Category not found");
            }
            if (!await _context.Videos.AnyAsync(v => v.Id == videoId))
            {
                throw new Exception("Video not found");
            }
            return await _context.Categories.Include(c => c.Videos).AnyAsync(c => c.Id == categoryId && c.Videos.Any(v => v.Id == videoId));
        }

        public async Task<List<Video>> GetVideosByExcludedSeriesIdAsync(int excludedSeriesId)
        {
            if (!await _context.Series.AnyAsync(s => s.Id == excludedSeriesId))
            {
                throw new Exception("Series not found");
            }
            return await _context.Videos.Include(v => v.Series).Where(v => !v.Series.Any(s => s.Id == excludedSeriesId)).ToListAsync();
        }

        public async Task<List<Video>> GetVideosByExcludedCategoryIdAsync(int excludedCategoryId)
        {
            if (!await _context.Categories.AnyAsync(c => c.Id == excludedCategoryId))
            {
                throw new Exception("Category not found");
            }
            return await _context.Videos.Include(v => v.Categories).Where(v => !v.Categories.Any(c => c.Id == excludedCategoryId)).ToListAsync();
        }

        public async Task<List<Video>> GetVideosByExcludedTagIdAsync(int excludedTagId)
        {
            if (!await _context.Tags.AnyAsync(t => t.Id == excludedTagId))
            {
                throw new Exception("Tag not found");
            }
            return await _context.Videos.Include(v => v.Tags).Where(v => !v.Tags.Any(t => t.Id == excludedTagId)).ToListAsync();
        }

    }
}
