using NetFilmx_Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Video_Tags", Schema = "NetFilmx")]
    public class VideoTag : BaseEntity
    {
        protected VideoTag() { }

        public VideoTag(int videoId, int tagId)
        {
            VideoId = videoId;
            TagId = tagId;
        }

        [Required]
        public int VideoId { get; set; }

        [ForeignKey("Video_Id")]
        public virtual Video Video { get; set; }

        [Required]
        public int TagId { get; set; }

        [ForeignKey("Tag_Id")]
        public virtual Tag Tag { get; set; }
    }
}
