using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.User
{
    public class UserEditDto
    {

        public UserEditDto (int id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }


        public int Id { get; }
        public string Username { get; }

        public string Email { get; }

        public string Password { get; }

    }
}
