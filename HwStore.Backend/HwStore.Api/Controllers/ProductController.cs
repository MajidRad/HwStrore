using HwStore.Application.DTOs.Product;
using HwStore.Application.Features.Products.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HwStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDto_Base>>> Products()
        {
            var products = await _mediator.Send(new GetProductListRequest());
            return Ok(products);
        }
 
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto_Details>> product(int id)
        {
            var product = await _mediator.Send(new GetProductByIdRequest() { Id = id });
            return Ok(product);
        }
    }
}
