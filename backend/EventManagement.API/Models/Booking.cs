using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.API.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        
        [Required]
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }
        
        [Required]
        public string CustomerName { get; set; }
        
        [Required]
        public string CustomerEmail { get; set; }

        public string CateringPackage { get; set; } // e.g., "Premium Dinner Buffet B"

        public string AudioVisualEquipment { get; set; } // e.g., "Concert Stage & Sound System"

        public string DigitalSignatureUrl { get; set; }

        public bool IsSigned { get; set; } = false;

        public DateTime? SignedDate { get; set; }

        public string QrCodeRef { get; set; } // e.g., "#EV-2026-99"
        
        public string BookingStatus { get; set; } = "Pending"; // Pending, Confirmed & Signed, Revision Requested, Cancelled

        public string RevisionNotes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}