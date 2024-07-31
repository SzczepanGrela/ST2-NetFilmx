using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Comment
{
    public sealed class DeleteCommentCommand : ICommand
    {

        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
        public int Id { get;}

    }
}
