using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Comment
{
    public class CommentDetailsDto
    {
        public CommentDetailsDto(int id, int videoId, int userId, string content, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            VideoId = videoId;
            UserId = userId;
            Content = content;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int VideoId { get; }

        public int Id { get; }

        public int UserId { get; }

        public string Content { get; } 

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; }


    }
}
