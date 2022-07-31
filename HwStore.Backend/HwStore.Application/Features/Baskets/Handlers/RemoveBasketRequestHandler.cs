using AutoMapper;
using HwStore.Application.Features.Baskets.Requsts.Commands;
using MediatR;

namespace HwStore.Application.Features.Baskets.Handlers;

public class RemoveBasketRequestHandler : IRequestHandler<RemoveBasketRequest, Result<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveBasketRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Unit>> Handle(RemoveBasketRequest request, CancellationToken cancellationToken)
    {

        var basket = await _unitOfWork.BasketRepository.GetFirstOrDefault(x => x.BuyerId == request.BuyerId);
        _unitOfWork.BasketRepository.Remove(basket);
        _unitOfWork.Save();
        return Result<Unit>.Success(Unit.Value);

    }
}
