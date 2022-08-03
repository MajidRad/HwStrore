using HwStore.Application.Contract.Identity;
using HwStore.Application.Core;
using HwStore.Application.DTOs.Order;
using HwStore.Application.Features.Baskets.Requsts.Queries;
using HwStore.Application.Features.Orders.Requests.Commands;
using HwStore.Application.Features.Orders.Requests.Queries;
using HwStore.Domain.Order;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HwStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : BaseApiController
{
    private readonly IAuthService _authService;

    public OrdersController(IMediator mediator, IAuthService authService) : base(mediator)
    {
        _authService = authService;
    }
    [HttpGet("GetOrders")]
    public async Task<ActionResult<List<Order>>> GetOrders()
    {
        var orders = await Mediator.Send(new GetOrderedRequest());
        return HandleResult(orders);
    }
    [HttpGet("GetOrder/{id}")]
    public async Task<ActionResult<Order>> GetOrders(int id)
    {
        var order = await Mediator.Send(new GetOrderRequest() { OrderId = id });
        return HandleResult(order);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder([FromBody] OrderDto_Create orderDto)
    {
        var basket = await Mediator.Send(new GetBasketRequest() { buyerId = User.Identity.Name });

        await Mediator
           .Send(new TransferBasketToOrderRequest() { Basket = basket.Value, OrderDto = orderDto });
        if(orderDto.SaveAddress) await _authService.UpdateUserAddress(orderDto);
        return Ok();
    }
}
