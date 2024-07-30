using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetById
{
    public sealed class GetVideoByIdQueryHandler<TDto> : IQueryHandler<GetVideoByIdQuery, QResult<TDto>>
    {
        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public GetVideoByIdQueryHandler(IVideoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetVideoByIdQuery query)
        {
            var video = _repository.GetVideoById(query.VideoId);
            if (video == null)
            {
                return QResult<TDto>.Fail("Video not found");
            }
            TDto videoDto;
            try
            {
                videoDto = _mapper.Map<TDto>(video);
                return QResult<TDto>.Ok(videoDto);
            }
            catch (Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }
            
        }
    }
}
