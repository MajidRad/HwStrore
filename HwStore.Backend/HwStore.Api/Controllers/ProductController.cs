using HwStore.Application.Core;
using HwStore.Application.DTOs.Product;
using HwStore.Application.Features.Products.Requests.Commands;
using HwStore.Application.Features.Products.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HwStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : BaseApiController
{
    public ProductController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<ProductDto_Base>>> Products([FromQuery] ProductParams productParams)
    {
        var products = await Mediator.Send(new GetProductListRequest() { Params = productParams });
        return HandlePagedResult(products);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto_Details>> product(int id)
    {
        var product = await Mediator.Send(new GetProductByIdRequest() { Id = id });
        return HandleResult<ProductDto_Details>(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto_Create product)
    {

        return HandleResult(await Mediator.Send(new CreateProductRequest() { Product = product }));
    }
}
