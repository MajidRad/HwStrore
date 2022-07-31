using HwStore.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity;

public class HwStoreIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public HwStoreIdentityDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(HwStoreIdentityDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}
