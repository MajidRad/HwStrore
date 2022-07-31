using HwStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.HasData(
           new ApplicationRole
           {
               Id = 1,
               Name = "User",
               NormalizedName = "USER"
           },
            new ApplicationRole
            {
                Id = 2,
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
            );
    }
}
