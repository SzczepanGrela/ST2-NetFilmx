using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetBySeriesId
{
    public sealed class GetVideosBySeriesIdQueryHandler<TDto> : IQueryHandler<GetVideosBySeriesIdQuery, QResult<List<TDto>>>
    {
        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public GetVideosBySeriesIdQueryHandler(IVideoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetVideosBySeriesIdQuery query)
        {
            
            
            List<TDto> videosDto;
            try
            {
                var videos = _repository.GetVideosBySeriesId(query.SeriesId);
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
