using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Series
{
    public class SeriesListDto : ISeriesDto
    {
        public SeriesListDto(string name, decimal price, int id)
        {
            Name = name;
            Price = price;
            Id = id;
        }

        public string Name { get; }

        public decimal Price { get; }

        public int Id { get; }




    }
}
