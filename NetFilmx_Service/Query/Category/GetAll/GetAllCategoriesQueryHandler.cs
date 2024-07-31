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
    public sealed class GetCategoryByIdQueryHandler<TDto> : IQueryHandler<GetCategoryByIdQuery<TDto>, QResult<TDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetCategoryByIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            var category = await _repository.GetCategoryByIdAsync(query.Id);
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
            catch (System.Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }
        }
    }
}
