using NetFilmx_Storage.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Categories", Schema = "NetFilmx_projekt")]
    public class Category : BaseEntity
    {
        internal Category()
        {
            VideoCategories = new List<VideoCategory>();
        }

        public Category(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [InverseProperty("Category")]   // InverseProperty allows the other side of
                                        // the relationship to be defined in the dependent entity.
        public virtual ICollection<VideoCategory> VideoCategories { get; set; }

        [NotMapped] // NotMapped attribute to exclude a property from the database.
        public IEnumerable<Video> Videos => VideoCategories.Select(vc => vc.Video);

    }
}
