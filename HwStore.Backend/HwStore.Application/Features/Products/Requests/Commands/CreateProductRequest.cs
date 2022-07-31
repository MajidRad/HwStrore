using MediatR;

namespace HwStore.Application.Features.Products.Requests.Commands;

public class CreateProductRequest : IRequest<Result<Unit>>
{
    public ProductDto_Create Product { get; set; }
}
