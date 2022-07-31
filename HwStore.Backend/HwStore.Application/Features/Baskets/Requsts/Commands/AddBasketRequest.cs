using HwStore.Application.DTOs.Basket;
using MediatR;

namespace HwStore.Application.Features.Baskets.Requsts.Commands;

public class AddBasketRequest : IRequest<Result<Unit>>
{
    public BasketDto_Base? Basket { get; set; }
}
