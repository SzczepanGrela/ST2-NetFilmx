using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetFilmx_Storage.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NetFilmxDbContext _context;
        

        public CategoryRepository(NetFilmxDbContext context)
        {
            _context = context;
           
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Category> GetCategoriesByVideoId(int videoId)
        {
           var videos = _context.Videos.Where(v => v.Id == videoId).Include(v => v.Categories).ToList();
            return videos.SelectMany(v => v.Categories).ToList();

        }

        public Category GetCategoryByName(string categoryName)
        {
            Category? category = _context.Categories.FirstOrDefault(c => c.Name == categoryName);
            return category == null ? throw new DataException("Category not found") : category;
        }
        


        public Category GetCategoryById(int categoryId)
        {
            Category? category = _context.Categories.Find(categoryId);
            return category == null ? throw new DataException("Category not found") : category;
        }


       

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            Category? category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public bool IsCategoryExist(string categoryName)
        {
            return _context.Categories.Any(c => c.Name == categoryName);
        }

        public bool IsCategoryExist(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }
    }
}
