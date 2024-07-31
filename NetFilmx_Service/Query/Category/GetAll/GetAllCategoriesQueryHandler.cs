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
    public sealed class GetAllCategoriesQueryHandler<TDto> : IQueryHandler<GetAllCategoriesQuery<TDto>, List<TDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetAllCategoriesQuery<TDto> query, CancellationToken cancellationToken)
        {
            List<TDto> categoryDtos;
            try
            {
                var categories = await _repository.GetAllCategoriesAsync();
                categoryDtos = _mapper.Map<List<TDto>>(categories);
                return QResult<List<TDto>>.Ok(categoryDtos);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
        }
    }
}
