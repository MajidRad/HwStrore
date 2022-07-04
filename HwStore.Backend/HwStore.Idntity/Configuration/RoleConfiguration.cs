using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Idntity.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "F9940470-CC55-4412-8492-DFD8F73867CF",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Id = "FBF75E5D-BC9C-4A8C-AD20-78FC64F64463",
                    Name = "User",
                    NormalizedName = "USER",
                }
                );
        }
    }
}
