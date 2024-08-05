using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.User
{
    public sealed class IsUsernameAvailableQuery : IRequest<QResult<bool>>
    {
        public IsUsernameAvailableQuery(string username, int? userId = null)
        {
            Username = username;
            Id = userId;
        }

        public string Username { get; }

        public int? Id { get; }
    }
}
