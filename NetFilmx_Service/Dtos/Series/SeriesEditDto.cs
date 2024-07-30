using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Series
{
    public class SeriesEditDto
    {

        public SeriesEditDto(int id, string name, string? description, decimal price)
        {
            Name = name;
            Id = id;
            Description = description;
            Price = price;
        }


        public string Name { get; }

        public int Id { get; }

        public string? Description { get; }

        public decimal Price { get; }


    }
}
