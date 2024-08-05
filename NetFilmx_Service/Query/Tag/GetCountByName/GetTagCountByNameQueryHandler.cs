using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagCountByNameQueryHandler : IRequestHandler<GetTagCountByNameQuery, QResult<int>>
    {
        private readonly ITagRepository _repository;

        public GetTagCountByNameQueryHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<QResult<int>> Handle(GetTagCountByNameQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = await _repository.GetVideosCountByTagNameAsync(query.TagName);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
