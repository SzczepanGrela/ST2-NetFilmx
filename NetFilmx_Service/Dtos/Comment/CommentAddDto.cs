using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public int UserId { get; set;  }

        public int VideoId { get; set;  }

        public string Content { get; set;  }

    }
}
