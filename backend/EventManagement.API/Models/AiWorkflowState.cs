using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.API.Models
{
    public class AiWorkflowState
    {
        [Key]
        public int StateId { get; set; }

        [Required]
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }

        public string WeatherRiskForecast { get; set; }

        public string WeatherSafeguardAdded { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProposedSubtotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ManagerDiscount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalProposedTotal { get; set; }

        public string ApprovalState { get; set; } = "Under Review";

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}