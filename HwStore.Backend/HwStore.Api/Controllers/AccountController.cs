using HwStore.Application.Contract.Identity;
using HwStore.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HwStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }
        [HttpPost("Register")]
        public async Task<ActionResult<RegisterationResponse>> Register(RegistarationRequest request)
        {
            return CreatedAtAction("Register", await _authService.Register(request));
        
        }
        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<ActionResult<AuthResponse>> CurrentUser()
        {
            return Ok();
        }

    }
}
