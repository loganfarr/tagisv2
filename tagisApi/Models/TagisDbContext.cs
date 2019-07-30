using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Resources;

namespace tagisApi.Models
{
    public class TagisDbContext : DbContext
    {
        public TagisDbContext(DbContextOptions<TagisDbContext> options)
            : base(options)
        {}

        public DbSet<OrderResource> Orders { get; set; }
    }
}