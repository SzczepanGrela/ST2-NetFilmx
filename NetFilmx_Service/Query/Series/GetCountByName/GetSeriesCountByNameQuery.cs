using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesCountByNameQuery : IRequest<QResult<int>>
    {
        public GetSeriesCountByNameQuery(string seriesName)
        {
            SeriesName = seriesName;
        }
        public string SeriesName { get; }

    }
}
