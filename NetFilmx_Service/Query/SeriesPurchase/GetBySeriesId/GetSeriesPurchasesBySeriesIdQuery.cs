using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.SeriesPurchase
{
    public sealed class GetSeriesPurchasesBySeriesIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetSeriesPurchasesBySeriesIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }

    }
}
