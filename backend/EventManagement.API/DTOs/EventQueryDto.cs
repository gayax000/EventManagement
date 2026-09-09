namespace EventManagement.API.DTOs
{
    public class EventCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string LocationGps { get; set; } = string.Empty;
        public int GuestCount { get; set; }
        public decimal BudgetLimit { get; set; }
        public string InspirationImageUrl { get; set; } = string.Empty;
    }
 
    public class EventResponseDto
    {
        public int EventId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string LocationGps { get; set; } = string.Empty;
        public int GuestCount { get; set; }
        public decimal BudgetLimit { get; set; }
        public string InspirationImageUrl { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}