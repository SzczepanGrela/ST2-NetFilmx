using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User.Delete
{
    public sealed class DeleteUserCommand : ICommand
    {
        public int Id { get; }

    }
}
