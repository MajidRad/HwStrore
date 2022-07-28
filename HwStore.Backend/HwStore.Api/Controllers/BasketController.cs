using HwStore.Application.Core;
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
        public async Task<ActionResult<BasketDto_Base>> AddItemToBasket(int productId)
        {
            var basketDto_param = new BasketDto_Param() { productId = productId, quantity = 1 };
            var result = await Mediator.Send(new AddToBasketItemRequest 
            { AddToBasket= basketDto_param });
            return HandleResult(result);
        }

        [HttpPut("UpdateBasket")]
        public async Task<ActionResult<BasketDto_Base>> UpdateBasketItem(string buyerId, int productId,int quantity)
        {
            var basketDto_param = new BasketDto_Param() { productId = productId, quantity = quantity };
            var result = await Mediator.Send(new UpdateBasketRequest { Params = basketDto_param ,buyerId=buyerId});
            return HandleResult(result);
        }

        [HttpDelete("RemoveItem")]
        public async Task<ActionResult<BasketDto_Base>> RemoveBasketItem(int productId)
        {
            var basketDto_param = new BasketDto_Param { productId = productId };
            var result = await Mediator.Send(new RemoveBasketItemRequest { basketDto_Param = basketDto_param });
            
            return HandleResult(result);
        }

    }
}
