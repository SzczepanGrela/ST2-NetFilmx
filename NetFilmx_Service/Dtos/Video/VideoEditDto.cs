﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Video
{
    public class VideoEditDto : IVideoDto
    {
        public VideoEditDto() { }
        public VideoEditDto(int id, string title, string video_url, string? thumbnail_url, string? description, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
            Video_url = video_url;
            Thumbnail_url = thumbnail_url;
            Description = description;
        }



        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Title { get; set; }

        [StringLength(2000, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string? Description { get; set; }


        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 10001, ErrorMessage = "Price must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [StringLength(200, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Video_url { get; set; }

        [StringLength(200, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string? Thumbnail_url { get; set; }


    }
}
