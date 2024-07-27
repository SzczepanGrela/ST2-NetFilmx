using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int id);

        bool IsCategoryExist(string Name);
    }
}
