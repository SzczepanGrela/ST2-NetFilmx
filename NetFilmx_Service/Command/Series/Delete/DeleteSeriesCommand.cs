using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Series
{
    public sealed class DeleteSeriesCommand : IRequest<CResult>
    {

        public DeleteSeriesCommand(int id)
        {
            Id = id;
        }

        public int Id { get;}


    }
}
