using Microsoft.Identity.Client;
using NetFilmx_Storage.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Videos", Schema = "NetFilmx_dodaneZakupy")]
    public class Video : BaseEntity
    {
        internal Video()
        {
            Likes = new List<Like>();
            Comments = new List<Comment>();
            Categories = new List<Category>();
            Tags = new List<Tag>();
            Series = new List<Series>();
            VideoPurchases = new List<VideoPurchase>();
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
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 10001)]
        public decimal Price { get; set; } = 0;

        [Required]
        [MinLength(3)]
        public string VideoUrl { get; set; }

        [MinLength(3)]
        [Required]
        public string ThumbnailUrl { get; set; } = "www.example.img";

        [Required]
        public int Views { get; set; } = 0;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        [InverseProperty(nameof(Like.Video))]
        public virtual ICollection<Like> Likes { get; set; }


        [InverseProperty(nameof(Comment.Video))]
        public virtual ICollection<Comment> Comments { get; set; }


        [InverseProperty(nameof(Category.Videos))]
        public virtual ICollection<Category> Categories { get; set; }


        [InverseProperty(nameof(Tag.Videos))]
        public virtual ICollection<Tag> Tags { get; set; }


        [InverseProperty(nameof(Entities.Series.Videos))]
        public virtual ICollection<Series> Series { get; set; }


        [InverseProperty(nameof(VideoPurchase.Video))]
        public virtual ICollection<VideoPurchase> VideoPurchases { get; set; }
    }
}
