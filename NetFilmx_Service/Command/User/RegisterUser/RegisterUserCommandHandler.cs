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

        public CResult Handle(RegisterUserCommand command)
        {
            if(command == null)
            {
                return CResult.Fail("Command is null");
            }

            var validation = new RegisterUserCommandValidator().Validate(command);
            if(!validation.IsValid)
            {
                return CResult.Fail(validation.Errors.ToString());
            }

            try
            {

                var user = new NetFilmx_Storage.Entities.User(command.Username, command.Email, command.Password);


                _repository.AddUser(user);
            } catch(Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            return CResult.Ok();
        }



    }
}
