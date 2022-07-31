using MediatR;

namespace HwStore.Application.Features.Specifications.Requests.Queries;

public class GetSpecByProductIdRequest : IRequest<Result<List<SpecificationDto_Base>>>
{
    public int productId { get; set; }
}
