using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Comment
{
    public sealed class GetCommentsByUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetCommentsByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }
    }
}
