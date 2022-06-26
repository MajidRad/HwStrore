using HwStore.Application.DTOs.Category;
using HwStore.Application.DTOs.Product;
using HwStore.Application.Features.Category.Requests.Queries;
using HwStore.Application.Features.Products.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HwStore.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {


        public CategoryController(IMediator mediator) : base(mediator) { }
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto_Base>>> GetCategories()
        {
            var categories = await Mediator.Send(new GetCategoryListRequest());
            return HandleResult(categories);
        }

 
    }
}
