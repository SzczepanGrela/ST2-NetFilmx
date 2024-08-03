using MediatR;

namespace NetFilmx_Service.Command.User
{
    public sealed class DeleteUserCommand : IRequest<CResult>
    {

        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }

    }
}
