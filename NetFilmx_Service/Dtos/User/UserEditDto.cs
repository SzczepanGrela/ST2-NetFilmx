using System.ComponentModel.DataAnnotations;

namespace NetFilmx_Service.Dtos.User
{
    public class UserEditDto : IUserDto
    {
        public UserEditDto() { }

        public UserEditDto(int id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;

        }


        public int Id { get; set; }


        [MinLength(5, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Username { get; set; }

        [MinLength(5, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Email { get; set; }


    }
}
