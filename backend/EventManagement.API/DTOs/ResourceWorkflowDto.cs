namespace EventManagement.API.DTOs
{
    public class ResourceCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Venue, Equipment, Caterer, Decorator
        public string Location { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int Capacity { get; set; }
        public string ContactInfo { get; set; } = string.Empty;
    }
 
    public class AiWorkflowStateUpdateDto
    {
        public int EventId { get; set; }
        public string WeatherRiskAssessment { get; set; } = string.Empty;
        public string AiGeneratedProposal { get; set; } = string.Empty;
        public decimal CalculatedTotalCost { get; set; }
        public string CurrentStep { get; set; } = string.Empty; // e.g., "WireframeReview", "BudgetApproved"
    }
}