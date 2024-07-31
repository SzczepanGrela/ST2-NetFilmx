using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Category
{
    public class CategoryDetailsDto : ICategoryDto
    {

        public CategoryDetailsDto(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }



        public string Name { get; }

        public int Id { get; }

        public string Description { get; }

    }
}
