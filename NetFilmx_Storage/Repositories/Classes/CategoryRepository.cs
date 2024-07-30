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
           if(!_context.Videos.Any(v => v.Id == videoId))
            {
                throw new DataException("Video not found");
            }
            return _context.Videos.Where(v => v.Id == videoId).SelectMany(v => v.Categories).ToList();

        }

        public Category GetCategoryByName(string categoryName)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Name == categoryName);
            return category == null ? throw new DataException("Category not found") : category;
        }
        


        public Category GetCategoryById(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            return category == null ? throw new DataException("Category not found") : category;
        }


       

        public void AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }
            if (IsCategoryExist(category.Name))
            {
                throw new InvalidOperationException("A category with this name already exists");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }
            if (!IsCategoryExist(category.Id))
            {
                throw new DataException("Category not found");
            }
            _context.Categories.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category == null)
            {
                throw new DataException("Category not found");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
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
