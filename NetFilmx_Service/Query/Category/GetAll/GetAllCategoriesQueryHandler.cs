using AutoMapper;
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
    public sealed class GetAllCategoriesQueryHandler<TDto> : IQueryHandler<GetAllCategoriesQuery, QResult<List<TDto>>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetAllCategoriesQuery query)
        {
            var categories = _repository.GetAllCategories();
            
            List<TDto> categoriesDto;
            try
            {
                categoriesDto = _mapper.Map<List<TDto>>(categories);
                return QResult<List<TDto>>.Ok(categoriesDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
            
        }
    }
}
