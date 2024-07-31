using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Category>> GetCategoriesByVideoIdAsync(int videoId);

        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<Category> GetCategoryByNameAsync(string categoryName);

        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);

        Task<bool> IsCategoryExistAsync(string categoryName);
        Task<bool> IsCategoryExistAsync(int categoryId);

        Task<int> GetCategoryCountByIdAsync(int categoryId);
        Task<int> GetCategoryCountByNameAsync(string categoryName);
    }
}
