using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NetFilmx_Service.Command.Category.Add;
using NetFilmx_Service.Command.Category.Edit;
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
