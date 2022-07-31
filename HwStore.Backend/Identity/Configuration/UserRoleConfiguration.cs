using HwStore.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.HasData(
            new IdentityUserRole<int>
            {
                RoleId =1,
                UserId = 2,
            },
            new IdentityUserRole<int>
            {
                RoleId = 2,
                UserId = 1
            });
        }
    }
}
