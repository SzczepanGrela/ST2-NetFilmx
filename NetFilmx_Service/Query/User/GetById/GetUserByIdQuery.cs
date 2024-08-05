using MediatR;
using NetFilmx_Service.Result;

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
