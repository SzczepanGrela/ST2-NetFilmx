using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByVideoPurchaseId
{
    public sealed class GetVideoByVideoPurchaseIdQueryHandler<TDto> : IQueryHandler<GetVideoByVideoPurchaseIdQuery, QResult<TDto>>
    {
        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public GetVideoByVideoPurchaseIdQueryHandler(IVideoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetVideoByVideoPurchaseIdQuery query)
        {
            var video = _repository.GetVideoByVideoPurchaseId(query.VideoPurchaseId);
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
