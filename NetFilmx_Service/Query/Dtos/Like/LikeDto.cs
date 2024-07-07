using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Dtos.Like
{
    public class LikeDto
    {

        public LikeDto(int id, int videoId, int userId, DateTime createdAt)
        {
            Id = id;
            VideoId = videoId;
            UserId = userId;
            CreatedAt = createdAt;
        }


        public int VideoId { get; }

        public int Id { get; }

        public int UserId { get; }

        public DateTime CreatedAt { get; }

     

    }
}
