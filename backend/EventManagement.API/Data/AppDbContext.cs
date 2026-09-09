using Microsoft.EntityFrameworkCore;
using EventManagement.API.Models;

namespace EventManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<AiWorkflowState> AiWorkflowStates { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Contract> Contracts { get; set; }
    }
}