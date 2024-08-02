using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.User
{
    public class UserPasswordDto : IUserDto
    {
        public UserPasswordDto() { }

        public UserPasswordDto(int id, string password)
        {
            Id = id;
            Password = password;
        }


        public int Id { get; set; }



        [MinLength(8, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]

        public string Password { get; set; }

    }
}
