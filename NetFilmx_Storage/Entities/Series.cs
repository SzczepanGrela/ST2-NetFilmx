﻿using NetFilmx_Storage.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Series", Schema = "NetFilmx")]
    public class Series : BaseEntity
    {
        protected Series() { }

        public Series(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public ICollection<VideoSeries> SeriesVideos { get; set; }
    }
}
