using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetById
{
    public sealed class GetCategoryByIdQueryHandler<TDto> : IQueryHandler<GetCategoryByIdQuery, QResult<TDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        

        public GetCategoryByIdQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetCategoryByIdQuery query)
        {
            var category = _repository.GetCategoryById(query.Id);
            if (category == null)
            {
                return QResult<TDto>.Fail("Category not found");
            }
            TDto categoryDto;
            try
            {
                categoryDto = _mapper.Map<TDto>(category);
                return QResult<TDto>.Ok(categoryDto);
            }
            catch (Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }
            
        }
    }
}
