using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.User
{
    public sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, CResult>
    {
        private readonly IUserRepository _repository;

        public AddUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            var validation = new AddUserCommandValidator().Validate(command);
            if (!validation.IsValid)
            {
                return CResult.Fail(validation.Errors.ToString());
            }

            try
            {
                var isUsernameTaken = await _repository.IsUsernameAvailableAsync(command.Username);

                if (isUsernameTaken)
                {
                    return CResult.Fail("Username is taken");
                }

                var user = new NetFilmx_Storage.Entities.User(command.Username, command.Email, command.Password);
                await _repository.AddUserAsync(user);

                return CResult.Ok();

            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }


        }



    }
}
