using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Tag
{
    public class TagDetailsDto : ITagDto
    {

        public TagDetailsDto(int id, string name)
        {
            Name = name;
            Id = id;

        }

        public string Name { get; }

        public int Id { get; }

    }
}
