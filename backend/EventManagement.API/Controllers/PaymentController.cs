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

        // GET: api/payments/event/{eventId}
        [HttpGet("event/{eventId}")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentsByEvent(int eventId)
        {
            return await _context.Payments
                .Where(p => p.EventId == eventId)
                .ToListAsync();
        }

        // POST: api/payments (Upload transaction slip / make payment)
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment([FromBody] PaymentCreateDto dto)
        {
            var payment = new Payment
            {
                EventId = dto.EventId,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod,
                SlipImageUrl = dto.SlipImageUrl,
                Status = "PENDING VERIFICATION",
                PaidAt = DateTime.UtcNow
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Payment slip uploaded successfully, awaiting verification.", paymentId = payment.PaymentId });
        }

        // PUT: api/payments/{id}/verify (Manager approves or rejects payment slip)
        [HttpPut("{id}/verify")]
        public async Task<IActionResult> VerifyPayment(int id, [FromBody] string status) // status: APPROVED / REJECTED
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound(new { message = "Payment record not found." });
            }

            payment.Status = status;
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Payment status updated to {status}." });
        }
    }
}