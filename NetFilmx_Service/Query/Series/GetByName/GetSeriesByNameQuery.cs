using MediatR;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesByNameQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetSeriesByNameQuery(string seriesName)
        {
            SeriesName = seriesName;
        }
        public string SeriesName { get; }
    }
}
