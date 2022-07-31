using AutoMapper;
using HwStore.Application.Features.Category.Requests.Queries;
using MediatR;

namespace HwStore.Application.Features.Category.Handlers.Queries;

public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, Result<List<CategoryDto_Base>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCategoryListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }



    async Task<Result<List<CategoryDto_Base>>> IRequestHandler<GetCategoryListRequest, Result<List<CategoryDto_Base>>>.Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork.CategoryRepository.GetListAsync();
        var mappedCategories = _mapper.Map<List<CategoryDto_Base>>(categories);
        return Result<List<CategoryDto_Base>>.Success(mappedCategories);
    }
}
