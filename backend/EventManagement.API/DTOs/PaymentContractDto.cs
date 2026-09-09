namespace EventManagement.API.DTOs
{
    public class PaymentCreateDto
    {
        public int EventId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty; // Bank Transfer, Credit Card, Slip Upload
        public string SlipImageUrl { get; set; } = string.Empty;
    }
 
    public class ContractCreateDto
    {
        public int EventId { get; set; }
        public string PdfUrl { get; set; } = string.Empty;
        public string DigitalSignature { get; set; } = string.Empty;
    }
}