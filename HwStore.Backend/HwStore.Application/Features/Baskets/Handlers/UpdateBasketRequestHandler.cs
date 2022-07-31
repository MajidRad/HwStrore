using AutoMapper;
using HwStore.Application.DTOs.Basket;
using HwStore.Application.DTOs.Basket.Validators;
using HwStore.Application.Features.Baskets.Requsts.Commands;
using MediatR;

namespace HwStore.Application.Features.Baskets.Handlers;

public class UpdateBasketRequestHandler : IRequestHandler<UpdateBasketRequest, Result<BasketDto_Base>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBasketRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<BasketDto_Base>> Handle(UpdateBasketRequest request, CancellationToken cancellationToken)
    {
        var basket = await _unitOfWork.BasketRepository.GetBasket(request.buyerId!);
        if (basket == null) return Result<BasketDto_Base>.Failure("buyerId is not valid");

        var validator = new BasketParamsValidator(_unitOfWork);
        var validateResult = await validator.ValidateAsync(request.Params);
        if (!validateResult.IsValid)
        {
            var res = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
            return Result<BasketDto_Base>.Failure(res);
        }
        if (basket.BasketItems == null) return Result<BasketDto_Base>.Failure("productId not valid");
        var basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == request.Params.productId);
        basketItem.QuantityInBasket = request.Params.quantity;

        await _unitOfWork.SaveAsync();
        var mapedResult = _mapper.Map<BasketDto_Base>(basket);
        return Result<BasketDto_Base>.Success(mapedResult);
    }


}
