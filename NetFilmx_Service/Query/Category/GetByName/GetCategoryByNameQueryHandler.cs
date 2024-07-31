using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoryByNameQueryHandler<TDto> : IRequestHandler<GetCategoryByNameQuery<TDto>, QResult<TDto>>
        where TDto : ICategoryDto
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoryByNameQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetCategoryByNameQuery<TDto> query, CancellationToken cancellationToken)
        {
            var category = await _repository.GetCategoryByNameAsync(query.Name);
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
