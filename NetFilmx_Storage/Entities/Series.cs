﻿using NetFilmx_Storage.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Series", Schema = "NetFilmx_dodaneZakupy")]
    public class Series : BaseEntity
    {
        internal Series()
        {
            Videos = new List<Video>();
            SeriesPurchases = new List<SeriesPurchase>();
        }

        public Series(string name, decimal price, string? description) : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Description = description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 10001)]
        public decimal Price { get; set; } = 0;

        [MaxLength(2000)]
        
        public string? Description { get; set; } 

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        
        [InverseProperty(nameof(Video.Series))]
        public virtual ICollection<Video> Videos { get; set; }


        [InverseProperty(nameof(SeriesPurchase.Series))]
        public virtual ICollection<SeriesPurchase> SeriesPurchases { get; set; }
    }
}
