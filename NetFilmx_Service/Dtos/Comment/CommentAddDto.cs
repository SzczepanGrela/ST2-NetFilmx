using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Service.Dtos.Comment
{
    public class CommentAddDto : ICommentDto
    {
        public CommentAddDto()
        {
        }

        public CommentAddDto(int userid, int videoid, string content)
        {
            VideoId = videoid;
            UserId = userid;
            Content = content;
        }



        [Required]
        [Column(TypeName = "integer")]
        [Range(0, 10000, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "integer")]
        [Range(0, 10000, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int VideoId { get; set; }


        [StringLength(1000, ErrorMessage = "The {0} must be at most {1} characters long.")]
        [Required]
        public string Content { get; set; }

    }
}
