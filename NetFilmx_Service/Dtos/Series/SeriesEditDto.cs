using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Series
{
    public class SeriesEditDto : ISeriesDto
    {
        public SeriesEditDto() { }
        public SeriesEditDto(int id, string name, string? description, decimal price)
        {
            Name = name;
            Id = id;
            Description = description;
            Price = price;
        }

        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Name { get; set; }

        public int Id { get; set; }

        [StringLength(2000, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 10001, ErrorMessage = "Price must be between {1} and {2}.")]
        public decimal Price { get; set; }


    }
}
