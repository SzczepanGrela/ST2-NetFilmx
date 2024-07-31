using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Comment.GetById
{
    public sealed class GetCommentByIdQueryHandler<TDto> : IQueryHandler<GetCommentByIdQuery<TDto>, TDto>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetCommentByIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            try
            {
                var comment = await _repository.GetCommentByIdAsync(query.CommentId); 
                if (comment == null)
                {
                    return QResult<TDto>.Fail("Comment not found");
                }

                var commentDto = _mapper.Map<TDto>(comment);
                return QResult<TDto>.Ok(commentDto);
            }
            catch (Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }
        }
    }
}
