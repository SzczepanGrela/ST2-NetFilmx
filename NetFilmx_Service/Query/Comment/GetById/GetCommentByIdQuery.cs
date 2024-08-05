using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Comment
{
    public sealed class GetCommentByIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetCommentByIdQuery(int commentId)
        {
            CommentId = commentId;
        }
        public int CommentId { get; }
    }
}
