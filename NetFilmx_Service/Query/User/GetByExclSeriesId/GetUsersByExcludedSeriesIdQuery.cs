using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.User
{
    public class GetUsersByExcludedSeriesIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetUsersByExcludedSeriesIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }

    }
}
