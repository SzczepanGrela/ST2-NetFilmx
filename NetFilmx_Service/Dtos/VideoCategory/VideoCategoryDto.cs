using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.VideoCategory
{
    public class VideoCategoryDto
    {

        public VideoCategoryDto(int id, int videoId, int categoryId)
        {
            Id = id;
            VideoId = videoId;
            CategoryId = categoryId;
        }


        public int Id { get; }

        public int VideoId { get; }

        public int CategoryId { get; }



    }
}
