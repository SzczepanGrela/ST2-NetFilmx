﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.Category
{
    public class CategoryAddDto : ICategoryDto
    {
        public CategoryAddDto()
        {
        }
        public CategoryAddDto(string name, string description)
        {
            Name = name;
            Description = description;
        }

        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Name { get; set; }

        [StringLength(2000, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string? Description { get; set; } 
    }
}
