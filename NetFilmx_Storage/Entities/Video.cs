using NetFilmx_Storage.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Videos", Schema = "NetFilmx_noweEntities")]
    public class Video : BaseEntity
    {
        internal Video()
        {
            Likes = new List<Like>();
            Comments = new List<Comment>();
            Categories = new List<Category>();
            Tags = new List<Tag>();
            Series = new List<Series>();
        }

        public Video(string title, string description, decimal price, string videoUrl, string? thumbnailUrl = null) : this()
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

        [MaxLength(2000)]
        public string Description { get; set; } = "-";

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } = 0;

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

        
        public virtual ICollection<Like> Likes { get; set; }

        
        public virtual ICollection<Comment> Comments { get; set; }

        
        public virtual ICollection<Category> Categories { get; set; }

        
        public virtual ICollection<Tag> Tags { get; set; }

        
        public virtual ICollection<Series> Series { get; set; }
    }
}
