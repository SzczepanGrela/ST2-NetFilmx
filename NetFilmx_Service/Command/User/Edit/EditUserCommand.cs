﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.User
{
    public sealed class EditUserCommand : IRequest<CResult>
    {


        public EditUserCommand(int id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;

        }

        public int Id { get; }
        public string Username { get; }

        public string Email { get; }



    }
}
