using System.ComponentModel.DataAnnotations;

namespace EventManagement.API.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Role { get; set; } = "Client"; // Client, Admin, Organizer

        public string AccountStatus { get; set; } = "Active"; // Active, Locked, Suspended

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}