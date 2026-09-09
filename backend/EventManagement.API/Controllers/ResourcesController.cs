using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagement.API.Data;
using EventManagement.API.Models;
 
namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly AppDbContext _context;
 
        public ResourcesController(AppDbContext context)
        {
            _context = context;
        }
 
        // GET: api/resources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resource>>> GetResources()
        {
            return await _context.Resources.ToListAsync();
        }
 
        // POST: api/resources
        [HttpPost]
        public async Task<ActionResult<Resource>> PostResource([FromBody] Resource resource)
        {
            _context.Resources.Add(resource);
            await _context.SaveChangesAsync();
 
            return CreatedAtAction(nameof(GetResources), new { id = resource.ResourceId }, resource);
        }
    }
}