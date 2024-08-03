using MediatR;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUserByIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }

    }
}
