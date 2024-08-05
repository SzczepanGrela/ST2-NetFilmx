using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesByExcludedVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {


        public GetSeriesByExcludedVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }

        public int VideoId { get; }

    }
}
