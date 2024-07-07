using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Tag> _dbSet;

        public TagRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Tag>();
        }

        public List<Tag> GetTags()
        {
            return _dbSet.ToList();
        }

        public Tag GetTagById(long id)
        {
            return _dbSet.Find(id);
        }

        public void AddTag(Tag tag)
        {
            _dbSet.Add(tag);
            _context.SaveChanges();
        }

        public void EditTag(Tag tag)
        {
            _dbSet.Attach(tag);
            _context.Entry(tag).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveTag(long id)
        {
            Tag tag = _dbSet.Find(id);
            if (tag != null)
            {
                _dbSet.Remove(tag);
                _context.SaveChanges();
            }
        }
    }
}
