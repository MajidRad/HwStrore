using HwStore.Application.DTOs.Specification;
using HwStore.Application.Features.Specifications.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HwStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpecificationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{prodId}")]
        public async Task<ActionResult<List<SpecificationDto_Base>>> GetSpecByProductId(int prodId)
        {
            var specs = await _mediator.Send(new GetSpecByProductIdRequest() { productId = prodId });
            return Ok(specs);
        }
    }
}
