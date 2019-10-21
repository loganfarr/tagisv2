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
        
        public DbSet<ProductResource> Products { get; set; }
        
        public DbSet<StoreResource> Stores { get; set; }
        
        public DbSet<OrderItemResource> OrderItems { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<UserRole> UserRoles { get; set; }
    }
}