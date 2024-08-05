using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesCountByNameQueryHandler : IRequestHandler<GetSeriesCountByNameQuery, QResult<int>>
    {
        private readonly ISeriesRepository _repository;

        public GetSeriesCountByNameQueryHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<QResult<int>> Handle(GetSeriesCountByNameQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = await _repository.GetVideosCountBySeriesNameAsync(query.SeriesName);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
