using HwStore.Application.DTOs.Basket;
using MediatR;

namespace HwStore.Application.Features.Baskets.Requsts.Queries;

public class GetBasketRequest : IRequest<Result<BasketDto_Base>>
{
    public string buyerId { get; set; }
}
