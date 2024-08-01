using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.VideoPurchase
{
    public class DeleteVideoPurchaseCommand : IRequest<CResult>
    {


        public DeleteVideoPurchaseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }

      
    }
}
