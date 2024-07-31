using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User.Edit
{
    public sealed class EditUserCommandHandler : ICommandHandler<EditUserCommand>
    {
        private readonly IUserRepository  _repository;

        public EditUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(EditUserCommand command, CancellationToken cancellationToken)
        {

            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            var validation = new EditUserCommandValidator().Validate(command);
            if(!validation.IsValid)
            {
                return CResult.Fail(validation.Errors.ToString());
            }
            try
            {
                var user = await _repository.GetUserByIdAsync(command.Id);

                //var user = task.Result;
               
                user.Email = command.Email;
                user.Username = command.Username;
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
