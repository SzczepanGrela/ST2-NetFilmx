using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesByIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetSeriesByIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }
    }
}
