
using HwStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace HwStore.Persistence
{
    public class HwStoreDbContext:DbContext
    {
        public HwStoreDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(HwStoreDbContext).Assembly);
        }
        public DbSet<Product>? Products { get; set; } 
        public DbSet<Image>? Images { get; set; }
        public DbSet<Detail>? Details { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        
      
    }
}