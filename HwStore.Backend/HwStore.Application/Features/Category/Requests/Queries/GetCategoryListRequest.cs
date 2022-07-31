using MediatR;

namespace HwStore.Application.Features.Category.Requests.Queries;

public class GetCategoryListRequest : IRequest<Result<List<CategoryDto_Base>>>
{
}
