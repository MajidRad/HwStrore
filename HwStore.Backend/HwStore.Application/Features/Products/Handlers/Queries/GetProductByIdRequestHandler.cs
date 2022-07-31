using AutoMapper;
using HwStore.Application.Features.Products.Requests.Queries;
using MediatR;

namespace HwStore.Application.Features.Products.Handlers.Queries;

public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, Result<ProductDto_Details>>
{

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductByIdRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    async Task<Result<ProductDto_Details>> IRequestHandler<GetProductByIdRequest, Result<ProductDto_Details>>.Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetProductWithDetails(request.Id);
        var mappedProduct = _mapper.Map<ProductDto_Details>(product);
        return Result<ProductDto_Details>.Success(mappedProduct);
    }
}
