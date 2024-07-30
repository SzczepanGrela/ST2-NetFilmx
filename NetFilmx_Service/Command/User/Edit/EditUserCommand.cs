using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User.Edit
{
    public sealed class EditUserCommand : ICommand
    {
        public int Id { get; }
        public string Username { get; }

        public string Email { get; }

        public string Password { get; }

    }
}
