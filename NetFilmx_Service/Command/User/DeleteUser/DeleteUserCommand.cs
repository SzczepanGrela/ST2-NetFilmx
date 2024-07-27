using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User.DeleteUser
{
    public sealed class DeleteUserCommand : ICommand
    {
        public int Id { get; }

    }
}
