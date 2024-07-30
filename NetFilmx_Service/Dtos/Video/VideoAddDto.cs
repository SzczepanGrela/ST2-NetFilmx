using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Video
{
    public class VideoAddDto
    {

        public VideoAddDto(string title, decimal price, string video_url, string? thumbnail_url, string? description)
        {
            Title = title;
            Price = price;
            Video_url = video_url;
            Thumbnail_url = thumbnail_url;
            Description = description;
        }

        public string Title { get; }

        public string? Description { get; }

        public decimal? Price { get; }

        public string Video_url { get; }

        public string? Thumbnail_url { get; }

    }
}
