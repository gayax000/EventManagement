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

        // GET: api/contracts/event/{eventId}
        [HttpGet("event/{eventId}")]
        public async Task<ActionResult<Contract>> GetContractByEvent(int eventId)
        {
            var contract = await _context.Contracts
                .FirstOrDefaultAsync(c => c.EventId == eventId);

            if (contract == null)
            {
                return NotFound(new { message = "Contract not found for this event." });
            }

            return contract;
        }

        // POST: api/contracts (Upload digital signature and contract agreement)
        [HttpPost]
        public async Task<ActionResult<Contract>> PostContract([FromBody] ContractCreateDto dto)
        {
            var contract = new Contract
            {
                EventId = dto.EventId,
                PdfUrl = dto.PdfUrl,
                DigitalSignature = dto.DigitalSignature,
                IsSigned = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Contract signed and generated successfully.", contractId = contract.ContractId });
        }
    }
}