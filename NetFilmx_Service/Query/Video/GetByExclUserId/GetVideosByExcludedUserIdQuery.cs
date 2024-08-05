using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByExcludedUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetVideosByExcludedUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
