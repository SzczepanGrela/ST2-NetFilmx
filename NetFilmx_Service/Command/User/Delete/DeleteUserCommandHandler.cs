﻿using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.User
{
    public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, CResult>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                await _repository.DeleteUserAsync(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }


        }


    }
}
