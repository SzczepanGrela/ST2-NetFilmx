using MediatR;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByExcludedSeriesQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetVideosByExcludedSeriesQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }
    }
}
