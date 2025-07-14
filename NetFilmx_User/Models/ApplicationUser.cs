using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NetFilmx_User.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Link to the NetFilmx custom User entity
        /// </summary>
        public int? NetFilmxUserId { get; set; }

        /// <summary>
        /// Display name for the user
        /// </summary>
        [MaxLength(100)]
        public string? DisplayName { get; set; }

        /// <summary>
        /// User's first name
        /// </summary>
        [MaxLength(50)]
        public string? FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        [MaxLength(50)]
        public string? LastName { get; set; }

        /// <summary>
        /// When the user was created
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// When the user was last updated
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Whether the user account is active
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// User's avatar URL
        /// </summary>
        [MaxLength(500)]
        public string? AvatarUrl { get; set; }

        /// <summary>
        /// User's timezone
        /// </summary>
        [MaxLength(50)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// User's preferred language
        /// </summary>
        [MaxLength(10)]
        public string? PreferredLanguage { get; set; } = "en";

        /// <summary>
        /// Last login time
        /// </summary>
        public DateTime? LastLoginAt { get; set; }

        /// <summary>
        /// Last activity time
        /// </summary>
        public DateTime? LastActivityAt { get; set; }
    }
}