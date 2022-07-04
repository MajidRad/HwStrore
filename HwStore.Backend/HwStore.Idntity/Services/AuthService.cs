using HwStore.Application.Contract.Identity;
using HwStore.Application.Models.Identity;
using HwStore.Idntity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace HwStore.Identity.Services
{
    public class AuthService : IAuthService 
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager; 
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
			_jwtSettings = jwtSettings.Value;
		}

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("user is NotFound");
            }
            var result = await _signInManager
                .PasswordSignInAsync(user, request.Password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new Exception($"Credential for {request.Email} arent valid");
            }
            var jwtSecurityToken = await GenerateToken(user);
            var token = new JwtSecurityTokenHandler().CreateToken(jwtSecurityToken);
            AuthResponse response = new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = user.UserName
            };
            return response;
        }
        public async Task<RegisterationResponse> Register(RegistarationRequest request)
        {
            var existedUser =await _userManager.FindByEmailAsync(request.Email);
            if (existedUser != null)
            {
                throw new Exception("User already Exist");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) throw new Exception($"{result.Errors}");
            await _userManager.AddToRoleAsync(user, "User");
            return new RegisterationResponse { userId = user.Id };
        }

        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaimes = new List<Claim>();
            // every user claim and get every role and turn inot claim 
            //and union with jwt claim and include to tokens 
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaimes.Add(new Claim(ClaimTypes.Role, roles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("Uid",user.Id)
            }
            .Union(userClaims)
            .Union(roleClaimes);

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signInCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer:_jwtSettings.Issuer,
                audience:_jwtSettings.Audience,
                claims:claims,
                expires:DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMiutes),
                signingCredentials:signInCredentials
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(jwtSecurityToken);
            return tokenHandler.WriteToken(jwtSecurityTokens);
        }
      
    }
}
