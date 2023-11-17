using nexus.Models;
using Microsoft.EntityFrameworkCore;

namespace nexus.Data
{
    public class NexusUsersDbContext : DbContext
    {
        public NexusUsersDbContext(DbContextOptions<NexusUsersDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}