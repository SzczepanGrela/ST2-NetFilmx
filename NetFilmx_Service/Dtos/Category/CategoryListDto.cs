using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Category
{
    public class CategoryListDto
    {
        public CategoryListDto(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public int Id { get; }
        public string Name { get; }

    }
}
