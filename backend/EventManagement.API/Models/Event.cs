using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.API.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime EventDate { get; set; }
        
        public string Location { get; set; }

        public string LocationGps { get; set; } // GPS Location string

        public int GuestCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BudgetLimit { get; set; }

        public string InspirationImageUrl { get; set; }
        
        public string Status { get; set; } = "UNDER MANAGER REVIEW"; // UNDER MANAGER REVIEW, APPROVED BY MANAGER, REVISION REQUESTED, COMPLETED
    }
}