using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetByVideoId
{
    public sealed class GetCategoryByVideoIdQueryHandler<TDto> : IQueryHandler<GetCategoryByVideoIdQuery, QResult<List<TDto>>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoryByVideoIdQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetCategoryByVideoIdQuery query)
        {
            
            List<TDto> categoriesDto;
            try
            {
                var categories = _repository.GetCategoriesByVideoId(query.VideoId);
                categoriesDto = _mapper.Map<List<TDto>>(categories);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
            return QResult<List<TDto>>.Ok(categoriesDto);
        }
    }
}
