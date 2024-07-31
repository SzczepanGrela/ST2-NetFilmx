using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetByVideoId
{
    public sealed class GetCategoryByVideoIdQueryHandler<TDto> : IQueryHandler<GetCategoryByVideoIdQuery<TDto>, List<TDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoryByVideoIdQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetCategoryByVideoIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            List<TDto> categoriesDto;
            try
            {
                var categories = await _repository.GetCategoriesByVideoIdAsync(query.VideoId);
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
