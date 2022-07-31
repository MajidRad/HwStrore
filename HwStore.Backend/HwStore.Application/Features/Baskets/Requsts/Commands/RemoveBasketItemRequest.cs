using HwStore.Application.DTOs.Basket;
using MediatR;

namespace HwStore.Application.Features.Baskets.Requsts.Commands;

public class RemoveBasketItemRequest : IRequest<Result<BasketDto_Base>>
{
    public BasketDto_Param? basketDto_Param { get; set; }
}
