using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Category>();
        }

        public List<Category> GetCategories()
        {
            return _dbSet.ToList();
        }

        public Category GetCategoryById(long id)
        {
            return _dbSet.Find(id);
        }

        public void AddCategory(Category category)
        {
            _dbSet.Add(category);
            _context.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            _dbSet.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveCategory(long id)
        {
            Category category = _dbSet.Find(id);
            if (category != null)
            {
                _dbSet.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
