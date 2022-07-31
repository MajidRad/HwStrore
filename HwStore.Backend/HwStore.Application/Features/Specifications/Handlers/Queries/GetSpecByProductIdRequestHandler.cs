using AutoMapper;
using HwStore.Application.Features.Specifications.Requests.Queries;
using MediatR;

namespace HwStore.Application.Features.Specifications.Handlers.Queries;

public class GetSpecByProductIdRequestHandler :
    IRequestHandler<GetSpecByProductIdRequest, Result<List<SpecificationDto_Base>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetSpecByProductIdRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }




    async Task<Result<List<SpecificationDto_Base>>> IRequestHandler<GetSpecByProductIdRequest, Result<List<SpecificationDto_Base>>>.Handle(GetSpecByProductIdRequest request, CancellationToken cancellationToken)
    {
        var specs = await _unitOfWork.SpecificationRepository.GetSpecById(request.productId);
        var mappedSpec = _mapper.Map<List<SpecificationDto_Base>>(specs);
        return Result<List<SpecificationDto_Base>>.Success(mappedSpec);
    }
}
