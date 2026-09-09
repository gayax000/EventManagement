using System.ComponentModel.DataAnnotations;

namespace EventManagement.API.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; } = "Client"; // Client, Admin, Organizer

        public string AccountStatus { get; set; } = "Active"; // Active, Locked, Suspended

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}