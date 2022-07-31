using MediatR;

namespace HwStore.Application.Features.Brands.Requests.Queries;

public class GetBrandListRequest : IRequest<Result<List<BrandDto_Base>>>
{
}
