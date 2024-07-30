using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetAll
{
    public sealed class GetAllVideosQueryHandler<TDto> : IQueryHandler<GetAllVideosQuery, QResult<List<TDto>>>
    {
        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public GetAllVideosQueryHandler(IVideoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetAllVideosQuery query)
        {
            
            
            List<TDto> videosDto;
            try
            {
                var videos = _repository.GetAllVideos();
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
