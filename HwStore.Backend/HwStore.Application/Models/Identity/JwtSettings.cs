using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Models.Identity
{
	public class JwtSettings
	{
		public string? Key { get; set; }
		public string? Issuer { get; set; }
		public string? Audience { get; set; }
		public double DurationInMiutes { get; set; }
	}
}
