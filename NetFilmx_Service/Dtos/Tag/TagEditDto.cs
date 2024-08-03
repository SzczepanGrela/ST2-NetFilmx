using System.ComponentModel.DataAnnotations;

namespace NetFilmx_Service.Dtos.Tag
{
    public class TagEditDto : ITagDto
    {
        public TagEditDto() { }
        public TagEditDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }


        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Name { get; set; }

    }
}
