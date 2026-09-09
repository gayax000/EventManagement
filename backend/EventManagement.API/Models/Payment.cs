using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.API.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int BookingId { get; set; }
        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public string SlipImageUrl { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        public string PaymentStatus { get; set; } = "Pending"; // Pending, Approved, Rejected

        public string AdminRemark { get; set; }
    }
}