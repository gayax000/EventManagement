using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagement.API.Data;
using EventManagement.API.Models;
 
namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiWorkflowStatesController : ControllerBase
    {
        private readonly AppDbContext _context;
 
        public AiWorkflowStatesController(AppDbContext context)
        {
            _context = context;
        }
 
        // GET: api/aiworkflowstates/event/{eventId}
       [HttpGet("event/{eventide}")]        
       public async Task<ActionResult<AiWorkflowState>> GetAiWorkflowByEvent(int eventId)
        {
            var state = await _context.AiWorkflowStates
                .FirstOrDefaultAsync(s => s.EventId == eventId);
 
            if (state == null)
            {
                return NotFound(new { message = "AI workflow state not found for this event." });
            }
 
            return state;
        }
 
        // POST: api/aiworkflowstates (Save weather risks, AI proposals, and totals)
        [HttpPost]
        public async Task<ActionResult<AiWorkflowState>> PostAiWorkflowState([FromBody] AiWorkflowState workflowState)
        {
            workflowState.UpdatedAt = DateTime.UtcNow;
            _context.AiWorkflowStates.Add(workflowState);
            await _context.SaveChangesAsync();
 
            return Ok(workflowState);
        }
    }
}