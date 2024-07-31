using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Video
{
    public class VideoListDto : IVideoDto
    {

        public VideoListDto(int id, string title, string thumbnailUrl, decimal price)
        {
            Id = id;
            Title = title;
            ThumbnailUrl = thumbnailUrl;
            Price = price;
        }


        public int Id { get; }

        public string Title { get; }

        public string ThumbnailUrl { get; }

        public decimal Price { get; }


    }
}
