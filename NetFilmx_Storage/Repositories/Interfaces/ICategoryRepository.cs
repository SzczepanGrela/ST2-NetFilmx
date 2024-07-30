using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        List<Category> GetCategoriesByVideoId(int videoId);

        Category GetCategoryById(int categoryId);
        Category GetCategoryByName(string categoryName);

      
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
        
        bool IsCategoryExist(string categoryName);
        bool IsCategoryExist(int categoryId);

        int GetCategoryCountById(int categoryId);
        int GetCategoryCountByName(string categoryName);
    }
}
