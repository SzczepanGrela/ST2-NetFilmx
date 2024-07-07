using System;
using System.Collections.Generic;
using NetFilmx_Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Users", Schema = "NetFilmx")]
    public class User : BaseEntity
    {
        protected User() { }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            SetPassword(password);
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }


        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Username { get; set; }


        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Required]
       
       
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }


}
