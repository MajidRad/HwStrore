using HwStore.Application.Models.Identity;
using HwStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Contract.Identity
{
	public interface IAuthService
	{
		public Task<AuthResponse> Login(AuthRequest request);
		public Task<RegisterationResponse> Register(RegistarationRequest request);
		public Task<ApplicationUser> GetCurrentUser();		
	}
}
