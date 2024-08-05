using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUsersBySeriesIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetUsersBySeriesIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }


    }
}
