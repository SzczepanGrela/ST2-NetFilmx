using NetFilmx_Storage.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Tags", Schema = "NetFilmx_dodaneZakupy")]
    public class Tag : BaseEntity
    {
        internal Tag() 
        {
            Videos = new List<Video>();
        }

        public Tag(string name) : this()
        {
            Name = name;
        }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }

        
        public virtual ICollection<Video> Videos { get; set; }

       
    }
}
