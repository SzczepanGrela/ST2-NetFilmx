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

        public List<Tag> GetTags()
        {
            return _context.Tags.ToList();
        }

        public Tag GetTagById(int id)
        {
            Tag? tag = _context.Tags.Find(id);
            return tag == null ? throw new Exception("Tag not found") : tag;
        }

        public void AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public void EditTag(Tag tag)
        {
            _context.Tags.Attach(tag);
            _context.Entry(tag).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTag(int id)
        {
            Tag? tag = _context.Tags.Find(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                _context.SaveChanges();
            }
        }

        public bool IsTagExist(string name)
        {
            return _context.Tags.Any(c => c.Name == name);
        }
    }
}
