using HwStore.Application.DTOs.Basket;
using HwStore.Application.Features.Baskets.Requsts.Commands;
using HwStore.Application.Features.Baskets.Requsts.Queries;
using HwStore.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HwStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseApiController
    {

        public BasketController(IMediator mediator) : base(mediator) { }

        [HttpGet("GetBasket")]
        public async Task<ActionResult<BasketDto_Base>> GetBasket()
        {
            var buyerId = Request.Cookies["buyerId"];
            var basket = await Mediator.Send(new GetBasketRequest() { buyerId = buyerId });
            return HandleResult(basket);
        }
        [HttpPost("AddItem")]
        public async Task<ActionResult> AddItemToBasket(int productId, int quantity)
        {
            var result = await Mediator.Send(new AddToBasketItemRequest 
            {  prodcutId = productId, quantity = quantity });
            return HandleResult(result);
        }


        private BasketDto_Base CreateBasket()
        {
            var buyerId = User.Identity?.Name;
            if (string.IsNullOrEmpty(buyerId))
            {
                buyerId = Guid.NewGuid().ToString();
                var cookieOption = new CookieOptions
                { Expires = DateTime.Now.AddDays(30), HttpOnly = true, IsEssential = true };
                Response.Cookies.Append("buyerId", buyerId, cookieOption);
            }
            var basket = new BasketDto_Base() { BuyerId = buyerId, };
            return basket;
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveBasketItem(int productId, int quantity)
        {
          
            var result = await Mediator.Send(new RemoveBasketItemRequest
            { productId = productId, quantity = quantity });
            return HandleResult(result);
        }

    }
}
