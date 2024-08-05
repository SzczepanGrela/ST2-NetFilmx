using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUsersByVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetUsersByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

    }
}
