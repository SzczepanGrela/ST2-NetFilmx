using NetFilmx_Storage.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Tags", Schema = "NetFilmx")]
    public class Tag : BaseEntity
    {
        protected Tag() { }

        public Tag(string name)
        {
            Name = name;
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<VideoTag> VideoTags { get; set; }
    }
}
