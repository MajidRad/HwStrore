using HwStore.Application.Contract.Identity;
using HwStore.Identity.Models.User;
using HwStore.Idntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HwStore.Identity.Services
{
    public class UserService
    {
        private readonly AuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(AuthService authService, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContext)
        {
            _authService = authService;
            _userManager = userManager;
            _httpContext = httpContext;
        }
        public async Task<UserDto_Detail> CurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(_httpContext.HttpContext.User.Identity.Name);
            return new UserDto_Detail
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = await _authService.GenerateToken(user),
            };
        }

    }
}
