using AutoMapper;
using NetFilmx_Service.Command.Category;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryListDto>();
            CreateMap<Category, CategoryDetailsDto>();
            CreateMap<Category, CategoryAddDto>();
            CreateMap<Category, CategoryEditDto>();

            CreateMap<CategoryEditDto, EditCategoryCommand>();
            CreateMap<CategoryAddDto, AddCategoryCommand>();

        }

    }
}
