﻿using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User.EditUser
{
    public sealed class EditUserCommandHandler : ICommandHandler<EditUserCommand>
    {
        private readonly IUserRepository  _repository;

        public EditUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(EditUserCommand command)
        {
            var validation = new EditUserCommandValidator().Validate(command);
            if(!validation.IsValid)
            {
                return Result.Fail(validation.Errors.ToString());
            }   

            var user = _repository.GetUserById(command.Id);
            if (user == null)
            {
                return Result.Fail("User not found");
            }


            user.Email = command.Email;
            user.Username = command.Username;
            user.SetPassword(command.Password);
            user.UpdatedAt = DateTime.Now;

            _repository.EditUser(user);

            return Result.Ok();
        }

    }
}
