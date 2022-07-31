using HwStore.Application.DTOs.Basket;
using MediatR;

namespace HwStore.Application.Features.Baskets.Requsts.Commands;

public class AddToBasketItemRequest : IRequest<Result<BasketDto_Base>>
{
    public BasketDto_Param AddToBasket { get; set; }
}
