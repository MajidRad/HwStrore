using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HwStore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Identity
{
    public class HwStoreIdentityDbContext:IdentityDbContext<ApplicationUser>
    {
        public HwStoreIdentityDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(HwStoreIdentityDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
