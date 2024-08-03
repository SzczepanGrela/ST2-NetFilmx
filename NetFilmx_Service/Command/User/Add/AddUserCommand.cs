using MediatR;

namespace NetFilmx_Service.Command.User
{
    public sealed class AddUserCommand : IRequest<CResult>
    {

        public AddUserCommand(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public string Username { get; }

        public string Email { get; }

        public string Password { get; }

    }
}
