using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Series.Edit
{
    public sealed class EditSeriesCommand : ICommand
    {

        public EditSeriesCommand(int id, string name, string? description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public string Name { get; }

        public int Id { get; }

        public string? Description { get;}

        public decimal Price { get; }


    }
}
