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
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "90435835-3AE1-428C-8739-6A6808180FCB",
                    RoleId = "F9940470-CC55-4412-8492-DFD8F73867CF"
                },
                new IdentityUserRole<string>
                {
                    UserId = "05F6BCC8-BFD0-42EB-9D21-11EDEEA98EFD",
                    RoleId = "FBF75E5D-BC9C-4A8C-AD20-78FC64F64463"
                }
                );
        }
    }
}
