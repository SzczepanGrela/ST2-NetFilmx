using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByCommentId
{
    public sealed class GetVideoByCommentIdQueryHandler<TDto> : IQueryHandler<GetVideoByCommentIdQuery, QResult<TDto>>
    {
        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public GetVideoByCommentIdQueryHandler(IVideoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetVideoByCommentIdQuery query)
        {
            var video = _repository.GetVideoByCommentId(query.CommentId);
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
