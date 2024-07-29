using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User.DeleteUser
{
    public sealed class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public CResult Handle(DeleteUserCommand command)
        {
            var user = _repository.GetUserById(command.Id);
            if (user == null)
            {
                return CResult.Fail("User not found");
            }

            _repository.DeleteUser(command.Id);

            return CResult.Ok();
        }


    }
}
