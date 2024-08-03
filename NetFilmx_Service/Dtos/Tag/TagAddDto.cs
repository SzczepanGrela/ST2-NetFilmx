using System.ComponentModel.DataAnnotations;

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
