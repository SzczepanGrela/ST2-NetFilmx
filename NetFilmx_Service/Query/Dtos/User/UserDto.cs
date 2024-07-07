using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Dtos.User
{
    public class UserDto
    {


        public UserDto( int id, string username, string email, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Username = username;
            Email = email;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }


        public string Username { get; }

        public int Id { get; }

        public string Email { get; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; }



    }
}
