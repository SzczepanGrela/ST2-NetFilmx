using NetFilmx_Storage.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NetFilmx_Storage.Entities
{
    [Table("Series", Schema = "NetFilmx_projekt")]
    public class Series : BaseEntity
    {
        internal Series()
        {
            Videos = new List<Video>();
        }

        public Series(string name, decimal price, string description, DateTime createdAt, DateTime updatedAt) : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } = 0;

        [MaxLength(2000)]
        public string Description { get; set; } = "-";

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

       
        public virtual ICollection<Video> Videos { get; set; }

        
    }
}
