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
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                  new ApplicationUser
                  {
                      Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                      Email = "Majidrad@hotmail.com",
                      UserName= "Majidrad@hotmail.com",
                      Address = "Karaj",
                      NormalizedEmail = "MAJIDRAD@HOTMAIL.COM",
                      NormalizedUserName = "MAJIDRAD@HOTMAIL.COM",
                      PasswordHash = hasher.HashPassword(null, "Majid@123"),
                      EmailConfirmed = true
                  },
                 new ApplicationUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
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
