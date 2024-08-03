using MediatR;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUserByCommentIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetUserByCommentIdQuery(int commentId)
        {
            CommentId = commentId;
        }
        public int CommentId { get; }

    }
}
