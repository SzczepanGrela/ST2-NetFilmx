using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.User
{
    public class UserAddDto : IUserDto
    {
        public UserAddDto()
        {
        }

        public UserAddDto(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }



        [MinLength(5, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Username { get; set; }


        [MinLength(5, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Email { get; set; }


        [MinLength(5, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Password { get; set; }

    }
}
