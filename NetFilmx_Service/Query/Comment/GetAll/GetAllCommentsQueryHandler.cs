using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Comment;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Comment
{
    public sealed class GetAllCommentsQueryHandler<TDto> : IRequestHandler<GetAllCommentsQuery<TDto>, QResult<List<TDto>>>
        where TDto : ICommentDto
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCommentsQueryHandler(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetAllCommentsQuery<TDto> query, CancellationToken cancellationToken)
        {
            try
            {
                var comments = await _repository.GetAllCommentsAsync();
                var commentsDto = _mapper.Map<List<TDto>>(comments);
                return QResult<List<TDto>>.Ok(commentsDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
        }
    }
}
