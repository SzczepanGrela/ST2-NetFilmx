using Microsoft.EntityFrameworkCore.Metadata;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Service.Query.Category.GetById;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetAll
{
    public sealed class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, QResult<CategoryDto>>
    {

        private readonly ICategoryRepository _categoryRepository;

        private readonly IAdHocMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public QResult<CategoryDto> Handle(GetAllCategoriesQuery query)
        {

            List<CategoryDto> categories = new List<CategoryDto>();

            var result = _categoryRepository.GetAllCategories();



            throw new Exception("Not implemented yet");
        }


    }
}
