using NetFilmx_Storage.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Tags", Schema = "NetFilmx")]
    public class Tag : BaseEntity
    {
        protected Tag() 
        {
            VideoTags = new List<VideoTag>();
        }

        public Tag(string name) : this()
        {
            Name = name;
        }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }

        [InverseProperty("Tag")]
        public ICollection<VideoTag> VideoTags { get; set; }
    }
}
