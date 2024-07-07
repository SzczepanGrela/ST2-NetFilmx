using NetFilmx_Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Video_Series", Schema = "NetFilmx")]
    public class VideoSeries : BaseEntity
    {
        protected VideoSeries() { }

        public VideoSeries(int seriesId, int videoId)
        {
            SeriesId = seriesId;
            VideoId = videoId;
        }

        [Required]
        public int SeriesId { get; set; }

        [ForeignKey("Series_Id")]
        public virtual Series Series { get; set; }

        [Required]
        public int VideoId { get; set; }

        [ForeignKey("Video_Id")]
        public virtual Video Video { get; set; }
    }
}
