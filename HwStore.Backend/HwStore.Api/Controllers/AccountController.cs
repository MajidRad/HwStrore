using HwStore.Api.DTOs;
using HwStore.Application.Contract.Identity;
using HwStore.Application.Core;
using HwStore.Application.DTOs.Basket;
using HwStore.Application.Features.Baskets.Requsts.Commands;
using HwStore.Application.Features.Baskets.Requsts.Queries;
using HwStore.Application.Models.Identity;
using Identity.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace HwStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly IAuthService _authService;
        private readonly TokenServices _tokenServices;

        public AccountController(IAuthService authService, TokenServices tokenServices, IMediator mediator) : base(mediator)
        {
            _tokenServices = tokenServices;
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            var user = await _authService.GetUser(request);
            var userBasket = await Mediator.Send(new GetBasketRequest() { buyerId = request.Email });
            var anonBasket = await Mediator.Send(new GetBasketRequest() { buyerId = Request.Cookies["buyerId"] });


            if (anonBasket != null && anonBasket.Value != null)
            {
                if(userBasket!=null&& userBasket.Value!=null)
                {
                    await Mediator.Send(new RemoveBasketRequest() { BuyerId = userBasket.Value.BuyerId });
                }
                await Mediator.Send(new TransferBasketToUserRequest() { Basket = anonBasket.Value, buyerId = user.Value.Email });
                Response.Cookies.Delete("buyerId");
            }
            var basket = anonBasket != null ? anonBasket.Value : userBasket.Value;
            var authResult = await _authService.Login(request,basket);
            return HandleResult<AuthResponse>(authResult);
        }
        [HttpPost("Register")]
        public async Task<ActionResult<RegisterationResponse>> Register(RegistarationRequest request)
        {
            return CreatedAtAction("Register", await _authService.Register(request));

        }
        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<ActionResult<UserDto>> CurrentUser()
        {
            var userName = User.Identity.Name;
            var userBasket = await Mediator.Send(new GetBasketRequest() { buyerId = userName });
            var user = await _authService.GetCurrentUser();
            var mappedUser = new UserDto
            { Email = user.Value.Email, Token = await _tokenServices.CreateToken(user.Value), Basket = userBasket.Value };

            return Ok(mappedUser);
        }

    }
}
