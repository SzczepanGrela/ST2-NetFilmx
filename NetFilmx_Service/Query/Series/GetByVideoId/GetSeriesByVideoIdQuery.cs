using MediatR;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesByVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetSeriesByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }
    }
}
