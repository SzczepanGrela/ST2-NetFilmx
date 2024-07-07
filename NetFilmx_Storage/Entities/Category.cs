using NetFilmx_Storage.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Categories", Schema = "NetFilmx")]
    public class Category : BaseEntity
    {
        protected Category() { }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public ICollection<VideoCategory> VideoCategories { get; set; }
    }
}
