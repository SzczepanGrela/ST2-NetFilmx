﻿using NetFilmx_Storage.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Categories", Schema = "NetFilmx_dodaneZakupy")]
    public class Category : BaseEntity
    {
        internal Category()
        {
            Videos= new List<Video>();
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

         
        public virtual ICollection<Video> Videos { get; set; }

       

    }
}
