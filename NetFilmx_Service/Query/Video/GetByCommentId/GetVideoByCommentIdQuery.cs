using MediatR;
using NetFilmx_Service.Result;

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
