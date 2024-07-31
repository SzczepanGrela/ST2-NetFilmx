using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User
{
    public sealed class DeleteUserCommand : ICommand
    {

        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }

    }
}
