using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HwStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : BaseApiController
{
    public OrdersController(IMediator mediator) : base(mediator)
    {
    }

}
