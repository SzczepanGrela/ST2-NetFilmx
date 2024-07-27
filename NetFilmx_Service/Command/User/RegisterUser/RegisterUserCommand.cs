using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User.RegisterUser
{
    public sealed class RegisterUserCommand : ICommand
    {
       

        public string Username { get; }

        public string Email { get; }

        public string Password { get; }

    }
}
