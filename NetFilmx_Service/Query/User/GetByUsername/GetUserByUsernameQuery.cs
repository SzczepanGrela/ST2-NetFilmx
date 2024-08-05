using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUserByUsernameQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetUserByUsernameQuery(string username)
        {
            Username = username;
        }
        public string Username { get; }

    }
}
