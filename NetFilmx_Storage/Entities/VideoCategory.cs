using NetFilmx_Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Video_Categories", Schema = "NetFilmx")]
    public class VideoCategory : BaseEntity
    {
        protected VideoCategory() 
        {
        }

        public VideoCategory(int videoId, int categoryId) : this()
        {
            VideoId = videoId;
            CategoryId = categoryId;
        }

        [Required]
        public int VideoId { get; set; }

        [ForeignKey(nameof(VideoId))]
        [InverseProperty("VideoCategories")]
        public virtual Video Video { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("VideoCategories")]
        public virtual Category Category { get; set; }
    }
}
