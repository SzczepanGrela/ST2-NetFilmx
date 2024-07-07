using NetFilmx_Storage.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Storage.Entities
{

    [Table("Videos", Schema = "NetFilmx")]
    public class Video : BaseEntity
    {
        protected Video() { }

        public Video(string title, string description, SqlMoney price, int category_id, string video_url, string thumbnail_url=null)
        {
         
            Title = title;
            Description = description;
            Price = price;
            Category_id = category_id;
            Video_url = video_url;
            Thumbnail_url = thumbnail_url;
            Created_at = DateTime.Now;
            Updated_at = DateTime.Now;

        }



        [Required]
        [MinLength(3)]
        [MaxLength(128)]
        public string? Title { get; set; }

        

        [Required]
        [MinLength(3)]
        public string? Description { get; set; } = null;


        [Required]
        public SqlMoney Price { get; set; } = 0;

        [Required]
        public int Category_id { get; set; }


        [Required]
        [MinLength(3)]
        public string? Video_url { get; set; }

        
        [MinLength(3)]
        public string? Thumbnail_url { get; set; }

       
        public int Views { get; set; } = 0;

       
        public DateTime Created_at { get; set; } = DateTime.Now;

        
        public DateTime Updated_at { get; set; } = DateTime.Now;

        public ICollection<Like> Likes { get; set; }

        public ICollection<Comment> Comments{ get; set; }

        public ICollection<VideoCategory> VideoCategories { get; set; }

        public ICollection<VideoTag> VideoTags { get; set; }

        public ICollection<VideoSeries> SeriesVideos { get; set; }






    }
}
