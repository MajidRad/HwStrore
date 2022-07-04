using HwStore.Application.Contract.Identity;
using HwStore.Application.Models.Identity;
using HwStore.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenServices _tokenServices;

        public AuthService(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager, TokenServices tokenServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception($"User whith this Email {request.Email} is not Found");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                throw new Exception($"Credintial is not valid for this{request.Email}");
            }
            var token = await _tokenServices.CreateToken(user);
            var response = new AuthResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = token,
            };
            return response;
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
                Address = request.Address,
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
    }
}
