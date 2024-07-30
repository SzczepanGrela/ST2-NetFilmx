using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Tag
{
    public class TagAddDto
    {

        public TagAddDto(string name)
        {
            Name = name;

        }

        public string Name { get; set; }

    }
}
