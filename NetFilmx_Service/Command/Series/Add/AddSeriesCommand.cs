using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Series.Add
{
    public sealed class AddSeriesCommand : ICommand
    {
        public string Name { get; }

        public string? Description { get; }

        public decimal Price { get; }


    }
}
