namespace EventManagement.API.DTOs
{
    public class PaymentCreateDto
    {
        public int EventId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // Bank Transfer, Credit Card, Slip Upload
        public string SlipImageUrl { get; set; }
    }
 
    public class ContractCreateDto
    {
        public int EventId { get; set; }
        public string PdfUrl { get; set; }
        public string DigitalSignature { get; set; }
    }
}