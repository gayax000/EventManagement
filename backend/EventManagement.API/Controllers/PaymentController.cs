using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagement.API.Data;
using EventManagement.API.Models;
using EventManagement.API.DTOs;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/payments/booking/{bookingId}
        [HttpGet("booking/{bookingId}")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentsByBooking(int bookingId)
        {
            return await _context.Payments
                .Where(p => p.BookingId == bookingId)
                .ToListAsync();
        }

        // POST: api/payments
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment([FromBody] PaymentCreateDto dto)
        {
            var payment = new Payment
            {
                BookingId = dto.EventId, // Using EventId from DTO mapped to BookingId
                AmountPaid = dto.Amount,
                PaymentMethod = dto.PaymentMethod,
                SlipImageUrl = dto.SlipImageUrl,
                PaymentStatus = "PENDING VERIFICATION",
                PaymentDate = DateTime.UtcNow,
                AdminRemark = "Pending review"
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Payment slip uploaded successfully, awaiting verification.", paymentId = payment.PaymentId });
        }

        // PUT: api/payments/{id}/verify
        [HttpPut("{id}/verify")]
        public async Task<IActionResult> VerifyPayment(int id, [FromBody] string status)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound(new { message = "Payment record not found." });
            }

            payment.PaymentStatus = status;
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Payment status updated to {status}." });
        }
    }
}