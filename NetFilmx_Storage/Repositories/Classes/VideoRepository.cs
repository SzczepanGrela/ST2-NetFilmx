using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;

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
            var category = await _context.Categories
                                         .Include(c => c.Videos)
                                         .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            return category.Videos.ToList();
        }

        public async Task<List<Video>> GetVideosByTagIdAsync(int tagId)
        {
            var tag = await _context.Tags
                                    .Include(t => t.Videos)
                                    .FirstOrDefaultAsync(t => t.Id == tagId);

            if (tag == null)
            {
                throw new Exception("Tag not found");
            }

            return tag.Videos.ToList();
        }

        public async Task<List<Video>> GetVideosBySeriesIdAsync(int seriesId)
        {
            var series = await _context.Series
                                       .Include(s => s.Videos)
                                       .FirstOrDefaultAsync(s => s.Id == seriesId);

            if (series == null)
            {
                throw new Exception("Series not found");
            }

            return series.Videos.ToList();
        }

        public async Task<List<Video>> GetVideosByUserIdAsync(int userId)
        {
            var user = await _context.Users
                                     .Include(u => u.VideoPurchases)
                                     .ThenInclude(vp => vp.Video)
                                     .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user.VideoPurchases.Select(vp => vp.Video).ToList();
        }

        public async Task<Video> GetVideoByVideoPurchaseIdAsync(int videoPurchaseId)
        {
            var videoPurchase = await _context.VideoPurchases
                                              .Include(vp => vp.Video)
                                              .FirstOrDefaultAsync(vp => vp.Id == videoPurchaseId);

            if (videoPurchase == null)
            {
                throw new Exception("Video purchase not found");
            }

            return videoPurchase.Video;
        }

        public async Task<Video> GetVideoByCommentIdAsync(int commentId)
        {
            var comment = await _context.Comments
                                        .Include(c => c.Video)
                                        .FirstOrDefaultAsync(c => c.Id == commentId);

            if (comment == null)
            {
                throw new Exception("Comment not found");
            }

            return comment.Video;
        }

        public async Task<Video> GetVideoByLikeIdAsync(int likeId)
        {
            var like = await _context.Likes
                                     .Include(l => l.Video)
                                     .FirstOrDefaultAsync(l => l.Id == likeId);

            if (like == null)
            {
                throw new Exception("Like not found");
            }

            return like.Video;
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

            _context.Videos.Update(video);
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
            var video = await _context.Videos.Include(v => v.Series).FirstOrDefaultAsync(v => v.Id == videoId);
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
            var video = await _context.Videos.Include(v => v.Categories).FirstOrDefaultAsync(v => v.Id == videoId);
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
            var video = await _context.Videos.Include(v => v.Tags).FirstOrDefaultAsync(v => v.Id == videoId);
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
            var video = await _context.Videos.Include(v => v.Series).FirstOrDefaultAsync(v => v.Id == videoId);
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
            var video = await _context.Videos.Include(v => v.Categories).FirstOrDefaultAsync(v => v.Id == videoId);
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
            var video = await _context.Videos.Include(v => v.Tags).FirstOrDefaultAsync(v => v.Id == videoId);
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
            var tag = await _context.Tags
                                    .Include(t => t.Videos)
                                    .FirstOrDefaultAsync(t => t.Id == tagId);

            if (tag == null)
            {
                throw new Exception("Tag not found");
            }

            if (!tag.Videos.Any(v => v.Id == videoId))
            {
                throw new Exception("Video not found in this tag");
            }

            return true;
        }

        public async Task<bool> IsVideoExistInSeriesAsync(int seriesId, int videoId)
        {
            var series = await _context.Series
                                       .Include(s => s.Videos)
                                       .FirstOrDefaultAsync(s => s.Id == seriesId);

            if (series == null)
            {
                throw new Exception("Series not found");
            }

            if (!series.Videos.Any(v => v.Id == videoId))
            {
                throw new Exception("Video not found in this series");
            }

            return true;
        }

        public async Task<bool> IsVideoExistInCategoryAsync(int categoryId, int videoId)
        {
            var category = await _context.Categories
                                        .Include(c => c.Videos)
                                        .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            if (!category.Videos.Any(v => v.Id == videoId))
            {
                throw new Exception("Video not found in this category");
            }

            return true;
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

        public async Task<List<Video>> GetVideosByExcludedUserIdAsync(int userId)
        {
            if (!await _context.Users.AnyAsync(u => u.Id == userId))
            {
                throw new Exception("User not found");
            }

            var purchasedVideoIds = await _context.VideoPurchases
                .Where(vp => vp.UserId == userId)
                .Select(vp => vp.VideoId)
                .ToListAsync();

            return await _context.Videos
                .Where(v => !purchasedVideoIds.Contains(v.Id))
                .ToListAsync();
        }



    }
}