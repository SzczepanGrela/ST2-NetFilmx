using MediatR;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetVideosByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }


    }
}
