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
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne(a => a.Address)
                .WithOne()
                .HasForeignKey<UserAddress>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

        

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                  new ApplicationUser
                  {
                      Id = 1,
                      Email = "Majidrad@hotmail.com",
                      UserName = "Majidrad@hotmail.com",
                      //Address = new UserAddress { },
                      NormalizedEmail = "MAJIDRAD@HOTMAIL.COM",
                      NormalizedUserName = "MAJIDRAD@HOTMAIL.COM",
                      PasswordHash = hasher.HashPassword(null, "Majid@123"),
                      EmailConfirmed = true
                  },
                 new ApplicationUser
                 {
                     Id =2,
                     Email = "test@test.com",
                     UserName = "test@test.com",
                     NormalizedEmail = "TEST@TEST.COM",
                     NormalizedUserName = "TEST@TEST.COM",
                     PasswordHash = hasher.HashPassword(null, "Majid@123"),
                     EmailConfirmed = true
                 }

                );


        }
    }
}
