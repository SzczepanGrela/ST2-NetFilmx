using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Comment.GetById
{
    public sealed class GetCommentByIdQueryHandler<TDto> : IQueryHandler<GetCommentByIdQuery, QResult<TDto>>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetCommentByIdQuery query)
        {
            var comment = _repository.GetCommentById(query.CommentId);
            if (comment == null)
            {
                return QResult<TDto>.Fail("Comment not found");
            }
            TDto commentDto;
            try
            {
                commentDto = _mapper.Map<TDto>(comment);
                return QResult<TDto>.Ok(commentDto);
            }
            catch (Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }
            
        }
    }
}
