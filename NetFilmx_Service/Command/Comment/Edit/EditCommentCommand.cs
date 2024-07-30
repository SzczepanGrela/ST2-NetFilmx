using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Comment.Edit
{
    public sealed class EditCommentCommand : ICommand
    {
        public int Id { get;}
        public string Content { get;}
    }
    
}
