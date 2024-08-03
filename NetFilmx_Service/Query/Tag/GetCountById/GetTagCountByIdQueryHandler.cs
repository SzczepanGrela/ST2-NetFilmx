using MediatR;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagCountByIdQueryHandler : IRequestHandler<GetTagCountByIdQuery, QResult<int>>
    {
        private readonly ITagRepository _repository;

        public GetTagCountByIdQueryHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<QResult<int>> Handle(GetTagCountByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = await _repository.GetTagCountByIdAsync(query.TagId);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
