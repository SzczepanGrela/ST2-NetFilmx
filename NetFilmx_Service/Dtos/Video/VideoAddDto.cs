using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Video
{
    public class VideoAddDto : IVideoDto
    {
        public VideoAddDto()
        {
        }

        public VideoAddDto(string title, decimal price, string videoUrl, string thumbnailUrl, string? description)
        {
            Title = title;
            Price = price;
            VideoUrl = videoUrl;
            ThumbnailUrl = thumbnailUrl;
            Description = description;
        }

        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Title { get; set; }

        [StringLength(2000, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string? Description { get; set; }


        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 10001, ErrorMessage = "Price must be between {1} and {2}.")]
        public decimal Price { get; set; }


        [StringLength(200, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string VideoUrl { get; set; }


        [StringLength(200, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string ThumbnailUrl { get; set; }

    }
}
