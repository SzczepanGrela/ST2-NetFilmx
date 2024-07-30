using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User.Add
{
    public sealed class AddUserCommand : ICommand
    {
       

        public string Username { get; }

        public string Email { get; }

        public string Password { get; }

    }
}
