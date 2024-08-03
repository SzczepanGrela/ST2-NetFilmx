using MediatR;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideoByLikeIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetVideoByLikeIdQuery(int likeId)
        {
            LikeId = likeId;
        }
        public int LikeId { get; }

    }
}
