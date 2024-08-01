using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Comment
{
    public sealed class DeleteCommentCommand : IRequest<CResult>
    {

        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
        public int Id { get;}

    }
}
