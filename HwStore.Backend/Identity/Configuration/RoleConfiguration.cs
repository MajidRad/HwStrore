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
}
