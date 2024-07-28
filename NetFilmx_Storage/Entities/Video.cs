using NetFilmx_Storage.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace NetFilmx_Storage.Entities
{
    [Table("Videos", Schema = "NetFilmx")]
    public class Video : BaseEntity
    {
        protected Video()
        {
            Likes = new List<Like>();
            Comments = new List<Comment>();
            VideoCategories = new List<VideoCategory>();
            VideoTags = new List<VideoTag>();
            VideoSeries = new List<VideoSeries>();
        }

        public Video(string title, string description, SqlMoney price, string videoUrl, string? thumbnailUrl = null) : this()
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description;
            Price = price;
            VideoUrl = videoUrl ?? throw new ArgumentNullException(nameof(videoUrl));
            ThumbnailUrl = thumbnailUrl;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        public string Description { get; set; } = "-";

        [Required]
        public SqlMoney Price { get; set; } = 0;

        [Required]
        [MinLength(3)]
        public string VideoUrl { get; set; }

        [MinLength(3)]
        public string? ThumbnailUrl { get; set; }

        public int Views { get; set; } = 0;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [InverseProperty("Video")]
        public virtual ICollection<Like> Likes { get; set; }

        [InverseProperty("Video")]
        public virtual ICollection<Comment> Comments { get; set; }

        [InverseProperty("Video")]
        public virtual ICollection<VideoCategory> VideoCategories { get; set; }

        [InverseProperty("Video")]
        public virtual ICollection<VideoTag> VideoTags { get; set; }

        [InverseProperty("Video")]
        public virtual ICollection<VideoSeries> VideoSeries { get; set; }
    }
}
