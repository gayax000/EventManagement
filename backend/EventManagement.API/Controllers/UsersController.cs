using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagement.API.Data;
using EventManagement.API.Models;
using EventManagement.API.DTOs;
using Microsoft.AspNetCore.Identity;
 
namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher = new();
 
        public UsersController(AppDbContext context)
        {
            _context = context;
        }
 
        // POST: api/users/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            // Email එක දැනටමත් පවතියීදැයි පරීක්ෂා කිරීම
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return BadRequest(new { message = "This email is already registered." });
            }
 
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Role = string.IsNullOrEmpty(dto.Role) ? "Client" : dto.Role,
                AccountStatus = "Active",
                CreatedAt = DateTime.UtcNow
            };
 
            // Password එක Secure Hash එකක් බවට පත් කිරීම
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
 
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
 
            return Ok(new { message = "User registered successfully!", userId = user.UserId });
        }
 
        // POST: api/users/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }
 
            // Password එක Verify කිරීම
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }
 
            return Ok(new 
            { 
                message = "Login successful!", 
                userId = user.UserId, 
                fullName = user.FullName, 
                email = user.Email, 
                role = user.Role 
            });
        }
 
        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }
 
            // PasswordHash එක Response එකේ නොයැවීමට සකස් කිරීම
            user.PasswordHash = string.Empty;
 
            return Ok(user);
        }
    }
}