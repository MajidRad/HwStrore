using HwStore.Idntity.Models;
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
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
            new ApplicationUser
            {
                Id = "90435835-3AE1-428C-8739-6A6808180FCB",
                FirstName = "Majid",
                LastName = "Rad",
                UserName = "Majidrad@hotmail.com",
                NormalizedUserName = "MAJIDRAD@HOTMAIL.COM",
                Email = "Majidrad@hotmil.com",
                NormalizedEmail = "MAJIDRAD@HOTMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "Majid@123"),
                EmailConfirmed = true,
            },
            new ApplicationUser
            {
                Id = "05F6BCC8-BFD0-42EB-9D21-11EDEEA98EFD",
                FirstName = "Tom",
                LastName = "Hardy",
                UserName = "Test@test.com",
                NormalizedUserName = "TEST@TEST.COM",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                PasswordHash = hasher.HashPassword(null, "Majid@123"),
                EmailConfirmed = true,
            }
            );

        }
    }
}
