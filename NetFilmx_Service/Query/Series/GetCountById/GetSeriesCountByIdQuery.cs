using MediatR;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesCountByIdQuery : IRequest<QResult<int>>
    {
        public GetSeriesCountByIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }

    }
}
