using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Category
{
    public class CategoryEditDto : ICategoryDto
    {
        public CategoryEditDto() { }

        public CategoryEditDto(string name, string description, int id)
        {
            Name = name;
            Description = description;
            Id = id;
        }


        public string Name { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }

    }
}
