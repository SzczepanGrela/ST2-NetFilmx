using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace NetFilmx_Service.Dtos.Tag
{
    public class TagAddDto : ITagDto
    {
        public TagAddDto()
        {
        }

        public TagAddDto(string name)
        {
            Name = name;

        }


        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Name { get; set; }

    }
}
