namespace EventManagement.API.DTOs
{
    public class EventCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string LocationGps { get; set; }
        public int GuestCount { get; set; }
        public decimal BudgetLimit { get; set; }
        public string InspirationImageUrl { get; set; }
    }
 
    public class EventResponseDto
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string LocationGps { get; set; }
        public int GuestCount { get; set; }
        public decimal BudgetLimit { get; set; }
        public string InspirationImageUrl { get; set; }
        public string Status { get; set; }
    }
}