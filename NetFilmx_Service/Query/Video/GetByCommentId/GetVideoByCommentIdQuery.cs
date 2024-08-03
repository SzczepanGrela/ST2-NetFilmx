using MediatR;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideoByCommentIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetVideoByCommentIdQuery(int commentId)
        {
            CommentId = commentId;
        }
        public int CommentId { get; }

    }
}
