using MediatR;

namespace HwStore.Application.Features.Products.Requests.Queries;

public class GetProductListRequest : IRequest<Result<PagedList<ProductDto_Base>>>
{
    public ProductParams Params { get; set; }
}
