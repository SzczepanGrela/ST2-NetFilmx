using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByExclCategoryId
{
    public sealed class GetVideosByExcludedCategoryQueryHandler<TDto> : IQueryHandler<GetVideosByExcludedCategoryQuery<TDto>, List<TDto>>
    {
        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public GetVideosByExcludedCategoryQueryHandler(IVideoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetVideosByExcludedCategoryQuery<TDto> query, CancellationToken cancellationToken)
        {
            List<TDto> videosDto;
            try
            {
                var videos = await _repository.GetVideosByExcludedCategoryIdAsync(query.CategoryId);
                videosDto = _mapper.Map<List<TDto>>(videos);
                return QResult<List<TDto>>.Ok(videosDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
        }
    }
}
