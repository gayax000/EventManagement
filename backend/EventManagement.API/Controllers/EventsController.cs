using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagement.API.Data;
using EventManagement.API.Models;
using EventManagement.API.DTOs;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/events (Get all events with optional search and status filtering)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents([FromQuery] string? search, [FromQuery] string? status)
        {
            var query = _context.Events.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.Title.Contains(search) || e.Location.Contains(search));
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(e => e.Status == status);
            }

            return await query.ToListAsync();
        }

        // GET: api/events/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);

            if (eventItem == null)
            {
                return NotFound(new { message = "Event not found." });
            }

            return eventItem;
        }

        // POST: api/events (Create a new event from mobile interface)
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent([FromBody] EventCreateDto dto)
        {
            var eventItem = new Event
            {
                Title = dto.Title,
                Description = dto.Description,
                EventDate = dto.EventDate,
                Location = dto.Location,
                LocationGps = dto.LocationGps,
                GuestCount = dto.GuestCount,
                BudgetLimit = dto.BudgetLimit,
                InspirationImageUrl = dto.InspirationImageUrl,
                Status = "UNDER MANAGER REVIEW"
            };

            _context.Events.Add(eventItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { id = eventItem.EventId }, eventItem);
        }

        // PUT: api/events/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, [FromBody] Event eventItem)
        {
            if (id != eventItem.EventId)
            {
                return BadRequest(new { message = "Event ID mismatch." });
            }

            _context.Entry(eventItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Events.Any(e => e.EventId == id))
                {
                    return NotFound(new { message = "Event not found." });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { message = "Event updated successfully." });
        }

        // PUT: api/events/{id}/status (Update specific event status by AI/Manager)
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateEventStatus(int id, [FromBody] string status)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound(new { message = "Event not found." });
            }

            eventItem.Status = status;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Event status updated successfully.", status = eventItem.Status });
        }

        // DELETE: api/events/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound(new { message = "Event not found." });
            }

            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Event deleted successfully." });
        }
    }
}