using MediatR;

namespace HwStore.Application.Features.Products.Requests.Queries;

public class GetProductByIdRequest : IRequest<Result<ProductDto_Details>>
{
    public int Id { get; set; }
}
