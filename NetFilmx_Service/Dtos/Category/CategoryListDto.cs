using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Category
{
    public class CategoryListDto
    {
        public CategoryListDto(string name)
        {
            Name = name;
        }

        public string Name { get; }

    }
}
