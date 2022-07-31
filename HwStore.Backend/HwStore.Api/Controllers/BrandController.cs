using HwStore.Application.DTOs.Brand;
using HwStore.Application.Features.Brands.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HwStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IMediator _mediator;

    public BrandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<BrandDto_Base>>> GetBrands()
    {
        var brands = await _mediator.Send(new GetBrandListRequest());
        return Ok(brands);
    }
}
