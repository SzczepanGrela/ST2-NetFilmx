using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int Id { get;}
        public string Content { get; set; }
    }
}
