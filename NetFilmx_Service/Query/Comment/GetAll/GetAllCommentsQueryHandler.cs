using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Comment.GetAll
{
    public sealed class GetAllCommentsQueryHandler<TDto>: IQueryHandler<GetAllCommentsQuery<TDto>, List<TDto>>
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
