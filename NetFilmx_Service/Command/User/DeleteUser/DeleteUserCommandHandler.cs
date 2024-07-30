﻿using NetFilmx_Storage.Repositories;
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
            if(command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                
                _repository.DeleteUser(command.Id);
            }catch(Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            return CResult.Ok();
        }


    }
}
