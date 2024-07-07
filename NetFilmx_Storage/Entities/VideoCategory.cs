using NetFilmx_Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Video_Categories", Schema = "NetFilmx")]
    public class VideoCategory : BaseEntity
    {
        protected VideoCategory() { }

        public VideoCategory(int videoId, int categoryId)
        {
            VideoId = videoId;
            CategoryId = categoryId;
        }

        [Required]
        public int VideoId { get; set; }

        [ForeignKey("Video_Id")]
        public virtual Video Video { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }
    }
}
