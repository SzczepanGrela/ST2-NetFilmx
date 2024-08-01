using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.User
{
    public class UserEditDto : IUserDto
    {
        public UserEditDto() { }

        public UserEditDto (int id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }


        public int Id { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
