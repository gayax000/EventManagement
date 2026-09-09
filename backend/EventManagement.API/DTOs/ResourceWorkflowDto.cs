namespace EventManagement.API.DTOs
{
    public class ResourceCreateDto
    {
        public string Name { get; set; }
        public string Type { get; set; } // Venue, Equipment, Caterer, Decorator
        public string Location { get; set; }
        public decimal Cost { get; set; }
        public int Capacity { get; set; }
        public string ContactInfo { get; set; }
    }
 
    public class AiWorkflowStateUpdateDto
    {
        public int EventId { get; set; }
        public string WeatherRiskAssessment { get; set; }
        public string AiGeneratedProposal { get; set; }
        public decimal CalculatedTotalCost { get; set; }
        public string CurrentStep { get; set; } // e.g., "WireframeReview", "BudgetApproved"
    }
}