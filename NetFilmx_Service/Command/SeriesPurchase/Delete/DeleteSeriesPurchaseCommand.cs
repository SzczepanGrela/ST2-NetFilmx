using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.SeriesPurchase
{
    public sealed class DeleteSeriesPurchaseCommand : IRequest<CResult>
    {

        public DeleteSeriesPurchaseCommand(int id)
        {
            Id = id;
        }

        public int Id { get;}

    }
}
