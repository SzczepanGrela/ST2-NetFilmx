using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Tag
{
    public class TagListDto
    {
        TagListDto( string name)
        {
            Name = name;
        }
        public string Name { get; }

    }
}
