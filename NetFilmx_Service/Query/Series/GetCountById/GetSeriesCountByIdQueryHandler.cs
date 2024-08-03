using MediatR;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesCountByIdQueryHandler : IRequestHandler<GetSeriesCountByIdQuery, QResult<int>>

    {
        private readonly ISeriesRepository _repository;

        public GetSeriesCountByIdQueryHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<QResult<int>> Handle(GetSeriesCountByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = await _repository.GetSeriesCountByIdAsync(query.SeriesId);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
