using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly NetFilmxDbContext _context;

        public TagRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public List<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }

        public List<Tag> GetTagsByVideoId(int videoId)
        {
            return _context.Tags.Include(t => t.Videos).Where(t => t.Videos.Any(v => v.Id == videoId)).ToList();
        }

        public Tag GetTagById(int tagId)
        {
            Tag? tag = _context.Tags.Find(tagId);
            return tag == null ? throw new Exception("Tag not found") : tag;
        }

        public Tag GetTagByName(string tagName)
        {
            Tag? tag = _context.Tags.FirstOrDefault(t => t.Name == tagName);
            return tag == null ? throw new Exception("Tag not found") : tag;
        }


        public void AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public void UpdateTag(Tag tag)
        {
            _context.Tags.Attach(tag);
            _context.Entry(tag).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTag(int tagId)
        {
            Tag? tag = _context.Tags.Find(tagId);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                _context.SaveChanges();
            }
        }

        public bool IsTagExist(string tagName)
        {
            return _context.Tags.Any(c => c.Name == tagName);
        }

        public bool IsTagExist(int tagId)
        {
            return _context.Tags.Any(c => c.Id == tagId);
        }
    }
}
