using HwStore.Application.Contract.Identity;
using HwStore.Application.Core;
using HwStore.Application.DTOs.Basket;
using HwStore.Application.DTOs.Order;
using HwStore.Application.Models.Identity;
using HwStore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenServices _tokenServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HwStoreIdentityDbContext _dbContext;

        public AuthService(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager, TokenServices tokenServices, IHttpContextAccessor httpContextAccessor, HwStoreIdentityDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }

        public async Task<Result<ApplicationUser>> GetCurrentUser()
        {
            var email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var user= await _userManager.FindByEmailAsync(email.ToString());
            if (user == null) return Result<ApplicationUser>.Failure("Credential is Not Valid", HttpStatusCode.Unauthorized);
            return Result<ApplicationUser>.Success(user);
        }

        public async Task<Result<AuthResponse>> Login(AuthRequest request, BasketDto_Base? Basket)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return Result<AuthResponse>.Failure("Credentials Not valid", HttpStatusCode.Unauthorized);
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                return Result<AuthResponse>.Failure("Credentials Not valid",HttpStatusCode.Unauthorized);
            }
            var token = await _tokenServices.CreateToken(user);
            var response = new AuthResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = token,
                Basket = Basket ?? null
            };
            return Result<AuthResponse>.Success(response);
        }
        public async Task<Result<ApplicationUser>> GetUser(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var checkPass = await _userManager.CheckPasswordAsync(user, request.Password);
            if (checkPass) return Result<ApplicationUser>.Success(user);
            return Result<ApplicationUser>.Failure("Credential not valid", HttpStatusCode.Unauthorized);
        }
        public async Task<RegisterationResponse> Register(RegistarationRequest request)
        {
            var existedUser = await _userManager.FindByEmailAsync(request.Email);
            if (existedUser != null)
            {
                throw new Exception($"User Already exist");
            }
            var user = new ApplicationUser()
            {
                Email = request.Email,
                //Address = request.Address,
                UserName = request.UserName,
                EmailConfirmed = true,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception($"{result.Errors}");
            }
            await _userManager.AddToRoleAsync(user, "User");
            return new RegisterationResponse()
            {
                userId = user.Id
            };
        }
        public async Task UpdateUserAddress(OrderDto_Create orderDto)
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(username);

            var address = new UserAddress()
            {
                Address1 = orderDto.ShippingAddress.Address1,
                City = orderDto.ShippingAddress.City,
                FullName = orderDto.ShippingAddress.FullName,
                PostalCode = orderDto.ShippingAddress.PostalCode,
            };
            user.Address = address;
            await _dbContext.SaveChangesAsync();

        }

      
    }
}
