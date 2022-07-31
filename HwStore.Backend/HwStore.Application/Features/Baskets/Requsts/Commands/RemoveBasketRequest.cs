using MediatR;

namespace HwStore.Application.Features.Baskets.Requsts.Commands;

public class RemoveBasketRequest : IRequest<Result<Unit>>
{
    public string? BuyerId { get; set; }
}
