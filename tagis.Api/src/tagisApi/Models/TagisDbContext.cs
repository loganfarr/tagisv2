using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Resources;

namespace tagisApi.Models
{
    public class TagisDbContext : DbContext
    {
        public TagisDbContext(DbContextOptions<TagisDbContext> options)
            : base(options)
        {}

        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Store> Stores { get; set; }
        
        public DbSet<OrderItem> OrderItems { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<UserRole> UserRoles { get; set; }
    }
}