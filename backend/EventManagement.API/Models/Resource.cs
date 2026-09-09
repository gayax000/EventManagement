using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.API.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ResourceType { get; set; } // Venue, Equipment, Catering

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public string AvailabilityStatus { get; set; } = "Available";
    }
}