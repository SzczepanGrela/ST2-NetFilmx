using NetFilmx_Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Video_Tags", Schema = "NetFilmx_projekt")]
    public class VideoTag : BaseEntity
    {
        internal VideoTag() { }

        public VideoTag(int videoId, int tagId)
        {
            VideoId = videoId;
            TagId = tagId;
        }

        [Required]
        public int VideoId { get; set; }

        [ForeignKey(nameof(VideoId))]
        [InverseProperty("VideoTags")]
        public virtual Video Video { get; set; }


        [Required]
        public int TagId { get; set; }

        [ForeignKey(nameof(TagId))]
        [InverseProperty("VideoTags")]
        public virtual Tag Tag { get; set; }
    }
}
