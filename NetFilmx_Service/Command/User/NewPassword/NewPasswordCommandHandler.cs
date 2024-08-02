using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.User
{
    public sealed class NewPasswordCommandHandler : IRequestHandler<NewPasswordCommand, CResult>
    {
        private readonly IUserRepository  _repository;

        public NewPasswordCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(NewPasswordCommand command, CancellationToken cancellationToken)
        {

            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            var validation = new NewPasswordCommandValidator().Validate(command);
            if(!validation.IsValid)
            {
                return CResult.Fail(validation.Errors.ToString());
            }
            try
            {
                var user = await _repository.GetUserByIdAsync(command.Id);

                //var user = task.Result;
               
                user.SetPassword(command.Password);
                user.UpdatedAt = DateTime.Now;

                await _repository.UpdateUserAsync(user);

                return CResult.Ok();
            }
            catch(Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            
        }

    }
}
