using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Dtos.Series
{
    public class SeriesDto
    {

        public SeriesDto(int id, string name, string description, decimal priced, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Priced = priced;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public string Name { get; }

        public int Id { get; }

        public string Description { get; }

        public decimal Priced { get; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; }


    }
}
