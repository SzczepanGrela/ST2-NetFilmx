using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.SeriesPurchase.Delete
{
    public sealed class DeleteSeriesPurchaseCommand : ICommand
    {

        public DeleteSeriesPurchaseCommand(int id)
        {
            Id = id;
        }

        public int Id { get;}

    }
}
