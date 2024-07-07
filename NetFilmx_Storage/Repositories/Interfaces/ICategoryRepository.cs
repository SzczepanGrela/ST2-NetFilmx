using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category GetCategoryById(long id);
        void AddCategory(Category category);
        void EditCategory(Category category);
        void RemoveCategory(long id);
    }
}
