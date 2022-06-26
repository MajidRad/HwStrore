using HwStore.Api.Extensions;
using HwStore.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HwStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();

        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value == null) return NotFound();
            if (result.IsSuccess && result.Value != null) return Ok(result.Value);
            if (result.IsSuccess == false && result.Error != null) return BadRequest(result.Error);
            if (result.IsSuccess == false && result.Errors != null)
            {
                return BadRequest(result.Errors);
            }
            return BadRequest(result.Error);
        }
        protected ActionResult HandlePagedResult<T>(Result<PagedList<T>> result)
        {

            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value == null) return NotFound();
            if (result.IsSuccess && result.Value != null)
            {
                Response.AddPaginationHeader(result.Value.CurrentPage, result.Value.PageSize, result.Value.TotalCount, result.Value.TotalPages);
                return Ok(result.Value);
            }
            if (result.IsSuccess == false && result.Error != null) return BadRequest(result.Error);
            if (result.IsSuccess == false && result.Errors != null)
            {
                return BadRequest(result.Errors);
            }
            return BadRequest(result.Error);
        }
    }
}
