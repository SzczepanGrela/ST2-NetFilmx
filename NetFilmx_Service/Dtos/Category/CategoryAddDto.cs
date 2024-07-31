using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Category
{
    public class CategoryAddDto : ICategoryDto
    {

        public CategoryAddDto(string name, string description)
        {
            Name = name;
            Description = description;
        }


        public string Name { get; }
        public string? Description { get; } 
    }
}
