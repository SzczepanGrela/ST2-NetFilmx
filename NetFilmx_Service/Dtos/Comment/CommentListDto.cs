using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Comment
{
    public class CommentListDto
    {


        public CommentListDto(int id, int userid, int videoid, string content, DateTime updatedat)
        {
            Id = id;
            UserId = userid;
            VideoId = videoid;
            Content = content;
            UpdatedAt = updatedat;
        }


        public int VideoId { get; }

        public int Id { get; }

        public int UserId { get; }

        public string Content { get; }

        public DateTime UpdatedAt { get; }


    }
}
