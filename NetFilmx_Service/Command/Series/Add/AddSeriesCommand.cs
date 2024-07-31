using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Series
{
    public sealed class AddSeriesCommand : ICommand
    {

        public AddSeriesCommand(string name, string? description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public string Name { get; }

        public string? Description { get; }

        public decimal Price { get; }


    }
}
