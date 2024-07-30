using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Series.Edit
{
    public sealed class EditSeriesCommand : ICommand
    {
        public string Name { get; }

        public int Id { get; }

        public string? Description { get;}

        public decimal Price { get; }


    }
}
