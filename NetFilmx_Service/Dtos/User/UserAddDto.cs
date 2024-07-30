using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.User
{
    public class UserAddDto
    {
        public UserAddDto(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public string Username { get; }

        public string Email { get; }

        public string Password { get; }

    }
}
