using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagement.API.Data;
using EventManagement.API.Models;
using EventManagement.API.DTOs;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContractsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/contracts/booking/{bookingId}
        [HttpGet("booking/{bookingId}")]
        public async Task<ActionResult<Contract>> GetContractByBooking(int bookingId)
        {
            var contract = await _context.Contracts
                .FirstOrDefaultAsync(c => c.BookingId == bookingId);

            if (contract == null)
            {
                return NotFound(new { message = "Contract not found for this booking." });
            }

            return contract;
        }

        // POST: api/contracts
// POST: api/contracts
        [HttpPost]
        public async Task<ActionResult<Contract>> PostContract([FromBody] ContractCreateDto dto)
        {
            var contract = new Contract
            {
                BookingId = dto.EventId,
                RefCode = "REF-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                PdfDocumentUrl = dto.PdfUrl,
                ClientSignature = dto.DigitalSignature,
                IsSigned = true,
                GeneratedAt = DateTime.UtcNow
            };

            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Contract signed and generated successfully.", contractId = contract.ContractId });
        }
    }
}