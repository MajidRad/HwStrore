
using HwStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace HwStore.Persistence
{
    public class HwStoreDbContext : DbContext
    {
        public HwStoreDbContext(DbContextOptions<HwStoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(HwStoreDbContext).Assembly);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<Product>? Products { get; set; } = null!;
        public DbSet<Image>? Images { get; set; } = null!;

        public DbSet<Category>? Categories { get; set; } = null!;
        public DbSet<Brand>? Brands { get; set; } = null!;
        public DbSet<Specification> Specifications { get; set; } = null!;

    }
}