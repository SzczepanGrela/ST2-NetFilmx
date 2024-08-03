using System.ComponentModel.DataAnnotations;

namespace NetFilmx_Service.Dtos.Comment
{
    public class CommentEditDto : ICommentDto
    {
        public CommentEditDto() { }
        public CommentEditDto(int id, string content)
        {
            Id = id;
            Content = content;
        }

        public int Id { get; set; }

        [StringLength(1000, ErrorMessage = "The {0} must be at most {1} characters long.")]
        [Required]
        public string Content { get; set; }
    }
}
