using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User.RegisterUser
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _repository;

        public RegisterUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(RegisterUserCommand command)
        {
            var validation = new RegisterUserCommandValidator().Validate(command);
            if(!validation.IsValid)
            {
                return Result.Fail(validation.Errors.ToString());
            }

            var isExist = _repository.GetUserByUsername().FirstOrDefault(x => x.Username == command.Username);
            if (isExist != null)
            {
                return Result.Fail("User already exists");
            }


            var user = new NetFilmx_Storage.Entities.User(command.Username, command.Email, command.Password);


            _repository.AddUser(user);

            return Result.Ok();
        }



    }
}
