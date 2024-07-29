using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.VideoTag
{
    public class VideoTagDto
    {

        public VideoTagDto(int id, int videoId, int tagId)
        {
            Id = id;
            VideoId = videoId;
            TagId = tagId;
        }

        public int Id { get; }

        public int VideoId { get; }

        public int TagId { get; }

    }
}
