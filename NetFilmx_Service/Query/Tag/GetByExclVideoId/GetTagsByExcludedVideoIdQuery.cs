using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagsByExcludedVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetTagsByExcludedVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

    }

}
