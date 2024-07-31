using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Category
{
    public class CategoryEditDto : ICategoryDto
    {

        public CategoryEditDto(string name, string description, int id)
        {
            Name = name;
            Description = description;
            Id = id;
        }


        public string Name { get; }

        public int Id { get; }

        public string Description { get; }

    }
}
