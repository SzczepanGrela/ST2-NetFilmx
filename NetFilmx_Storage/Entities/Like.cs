using NetFilmx_Storage.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Storage.Entities
{
    [Table("Likes", Schema = "NetFilmx_noweEntities")]
    public class Like : BaseEntity
    {
        internal Like() { }

        public Like(int videoId, int userId)
        {
            VideoId = videoId;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }


        [Required]
        public int VideoId { get; set; }


        [ForeignKey(nameof(VideoId))]
        [InverseProperty("Likes")]
        public virtual Video Video { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Likes")]
        public virtual User User { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
