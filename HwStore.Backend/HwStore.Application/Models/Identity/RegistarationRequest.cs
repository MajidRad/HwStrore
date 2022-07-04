using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Models.Identity
{
	public class RegistarationRequest
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? UserName { get; set; }
		public string? Password { get; set; }

	}
}
