using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly NetFilmxDbContext _context;

        public TagRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<List<Tag>> GetTagsByVideoIdAsync(int videoId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            if (video == null)
            {
                throw new Exception("Video not found");
            }

            return await _context.Tags.Include(t => t.Videos).Where(t => t.Videos.Any(v => v.Id == videoId)).ToListAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int tagId)
        {
            var tag = await _context.Tags.FindAsync(tagId);
            return tag ?? throw new Exception("Tag not found");
        }

        public async Task<Tag> GetTagByNameAsync(string tagName)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tagName);
            return tag ?? throw new Exception("Tag not found");
        }

        public async Task AddTagAsync(Tag tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag), "Tag cannot be null");
            }
            if (await IsTagExistAsync(tag.Name))
            {
                throw new InvalidOperationException("A tag with this name already exists");
            }
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTagAsync(Tag tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag), "Tag cannot be null");
            }
            if (!await IsTagExistAsync(tag.Id))
            {
                throw new Exception("Tag not found");
            }
            _context.Tags.Attach(tag);
            _context.Entry(tag).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tag>> GetTagsByExcludedVideoIdAsync(int videoId)
        {
            var video = await _context.Videos.Include(v => v.Tags).FirstOrDefaultAsync(v => v.Id == videoId);

            if (video == null)
            {
                throw new Exception("Video not found");
            }

            var allTags = await _context.Tags.ToListAsync();
            var excludedTags = allTags.Where(t => !video.Tags.Any(vt => vt.Id == t.Id)).ToList();

            return excludedTags;
        }



        public async Task DeleteTagAsync(int tagId)
        {
            var tag = await _context.Tags.FindAsync(tagId);
            if (tag == null)
            {
                throw new Exception("Tag not found");
            }
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsTagExistAsync(string tagName)
        {
            return await _context.Tags.AnyAsync(c => c.Name == tagName);
        }

        public async Task<bool> IsTagExistAsync(int tagId)
        {
            return await _context.Tags.AnyAsync(c => c.Id == tagId);
        }

        public async Task<int> GetTagCountByIdAsync(int tagId)
        {
            return await _context.Tags.Include(t => t.Videos).Where(t => t.Id == tagId).SelectMany(t => t.Videos).CountAsync();
        }

        public async Task<int> GetTagCountByNameAsync(string tagName)
        {
            return await _context.Tags.Include(t => t.Videos).Where(t => t.Name == tagName).SelectMany(t => t.Videos).CountAsync();
        }


    }
}
