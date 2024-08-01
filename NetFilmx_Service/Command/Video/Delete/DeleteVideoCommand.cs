using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class DeleteVideoCommand : IRequest<CResult>
    {

        public DeleteVideoCommand(int id)
        {

           Id = id;
        }

        public int Id { get; }


    }
}
