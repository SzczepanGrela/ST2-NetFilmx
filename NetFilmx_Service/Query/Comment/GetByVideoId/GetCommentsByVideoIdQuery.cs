using MediatR;

namespace NetFilmx_Service.Query.Comment
{
    public sealed class GetCommentsByVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetCommentsByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }
    }
}
