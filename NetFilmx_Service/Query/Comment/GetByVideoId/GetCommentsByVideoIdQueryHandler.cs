using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Comment.GetByVideoId
{
    public sealed class GetCommentsByVideoIdQueryHandler<TDto> : IQueryHandler<GetCommentsByVideoIdQuery, QResult<List<TDto>>>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public GetCommentsByVideoIdQueryHandler(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetCommentsByVideoIdQuery query)
        {
            
            List<TDto> commentsDto;
            try
            {
                var comments = _repository.GetCommentsByVideoId(query.VideoId);
                commentsDto = _mapper.Map<List<TDto>>(comments);
                return QResult<List<TDto>>.Ok(commentsDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
            
        }
    }
}
