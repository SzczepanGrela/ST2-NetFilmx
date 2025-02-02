﻿namespace NetFilmx_Service.Dtos.User
{
    public class UserDetailsDto : IUserDto
    {


        public UserDetailsDto(int id, string username, string email, DateTime createdAt, DateTime updatedAt)
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
