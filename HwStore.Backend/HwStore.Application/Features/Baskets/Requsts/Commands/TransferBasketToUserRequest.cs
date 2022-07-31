using HwStore.Application.DTOs.Basket;
using MediatR;

namespace HwStore.Application.Features.Baskets.Requsts.Commands;

public class TransferBasketToUserRequest : IRequest<Result<Unit>>
{
    public string? buyerId { get; set; }
    public BasketDto_Base? Basket { get; set; }
}
