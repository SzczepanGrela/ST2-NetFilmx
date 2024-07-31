using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Series
{
    public sealed class DeleteSeriesCommand : ICommand
    {

        public DeleteSeriesCommand(int id)
        {
            Id = id;
        }

        public int Id { get;}


    }
}
