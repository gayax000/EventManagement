using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.API.Models
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }

        [Required]
        public int BookingId { get; set; }
        [ForeignKey("BookingId")]
        public Booking? Booking { get; set; }

        public string RefCode { get; set; } = string.Empty;

        public string PdfDocumentUrl { get; set; } = string.Empty;

        public string? ClientSignature { get; set; }

        public bool IsSigned { get; set; } = true;

        public DateTime SignedDate { get; set; } = DateTime.UtcNow;

        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Signed & Verified";
    }
}