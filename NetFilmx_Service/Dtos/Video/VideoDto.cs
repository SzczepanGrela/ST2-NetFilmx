using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Video
{
    public class VideoDto
    {

        public VideoDto(int id, string title, string description, string videoUrl, string thumbnailUrl, decimal price, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Title = title;
            Description = description;
            VideoUrl = videoUrl;
            ThumbnailUrl = thumbnailUrl;
            Price = price;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int Id { get; }

        public string Title { get; }

        public string Description { get; }

        public string VideoUrl { get; }

        public string ThumbnailUrl { get; }

        public decimal Price { get; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; }


    }
}
