using HwStore.Idntity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Idntity
{
	public class HwStoreIdentityDbContext:IdentityDbContext<ApplicationUser>
	{
		public HwStoreIdentityDbContext(DbContextOptions options):base(options){}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
