using HwStore.Application.DTOs.Basket;
using HwStore.Application.DTOs.Order;
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
		public Task<Result<AuthResponse>> Login(AuthRequest request,BasketDto_Base?Basket);
		public Task<RegisterationResponse> Register(RegistarationRequest request);
		public Task<Result<ApplicationUser>> GetCurrentUser();
		public Task<Result<ApplicationUser>> GetUser(AuthRequest request);
		public Task UpdateUserAddress(OrderDto_Create orderDto);
	}
}
