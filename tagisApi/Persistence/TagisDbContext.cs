using Microsoft.EntityFrameworkCore;
using tagisApi.Models;

namespace tagisApi.Persistence
{
    public class TagisDbContext : DbContext
    {
        public TagisDbContext(DbContextOptions<TagisDbContext> options)
            : base(options)
        {}

        public DbSet<Order> Orders { get; set; }
    }
}