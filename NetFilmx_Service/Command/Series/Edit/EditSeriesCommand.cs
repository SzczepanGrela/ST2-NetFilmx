using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Series.Edit
{
    public sealed class EditSeriesCommand : ICommand
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        

        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }
}
