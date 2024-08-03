using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System.Data;

namespace NetFilmx_Storage.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NetFilmxDbContext _context;


        public CategoryRepository(NetFilmxDbContext context)
        {
            _context = context;

        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();

        }

        public async Task<List<Category>> GetCategoriesByVideoIdAsync(int videoId)
        {
            if (!await _context.Videos.AnyAsync(v => v.Id == videoId))
            {
                throw new ArgumentException("Video not found");
            }
            return await _context.Videos.Where(v => v.Id == videoId).SelectMany(v => v.Categories).ToListAsync();
        }


        public async Task<List<Category>> GetCategoriesByExcludedVideoIdAsync(int videoId)
        {
            var video = await _context.Videos.Include(v => v.Categories).FirstOrDefaultAsync(v => v.Id == videoId) ?? throw new ArgumentException("Video not found");

            var allCategories = await _context.Categories.ToListAsync();
            var excludedCategories = allCategories.Where(c => !video.Categories.Any(vc => vc.Id == c.Id)).ToList();

            return excludedCategories;
        }



        public async Task<Category> GetCategoryByNameAsync(string categoryName)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
            return category ?? throw new ArgumentException("Category not found");
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            return category ?? throw new ArgumentException("Category not found");
        }

        public async Task AddCategoryAsync(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }
            if (await IsCategoryExistAsync(category.Name))
            {
                throw new InvalidOperationException("A category with this name already exists");
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }
            if (!await IsCategoryExistAsync(category.Id))
            {
                throw new DataException("Category not found");
            }
            _context.Categories.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
            {
                throw new DataException("Category not found");
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsCategoryExistAsync(string categoryName)
        {
            return await _context.Categories.AnyAsync(c => c.Name == categoryName);
        }

        public async Task<bool> IsCategoryExistAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> GetCategoryCountByIdAsync(int categoryId)
        {
            return await _context.Categories.Include(c => c.Videos).Where(c => c.Id == categoryId).SelectMany(c => c.Videos).CountAsync();
        }

        public async Task<int> GetCategoryCountByNameAsync(string categoryName)
        {
            return await _context.Categories.Include(c => c.Videos).Where(c => c.Name == categoryName).SelectMany(c => c.Videos).CountAsync();
        }


    }
}
