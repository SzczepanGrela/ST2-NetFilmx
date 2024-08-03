using MediatR;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosBySeriesIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetVideosBySeriesIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }

    }
}
