using NetFilmx_Service.Command.User;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User.RegisterUser.Add
{
    public sealed class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly IUserRepository _repository;

        public AddUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            if(command == null)
            {
                return CResult.Fail("Command is null");
            }

            var validation = new AddUserCommandValidator().Validate(command);
            if(!validation.IsValid)
            {
                return CResult.Fail(validation.Errors.ToString());
            }

            try
            {
                var user = new NetFilmx_Storage.Entities.User(command.Username, command.Email, command.Password);
                await _repository.AddUserAsync(user);

                return CResult.Ok();

            } catch(Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            
        }



    }
}
