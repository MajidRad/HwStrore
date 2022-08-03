using AutoMapper;
using HwStore.Application.Features.Orders.Requests.Queries;
using HwStore.Domain.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Orders.Handlers.Queries;
public class GetOrderedRequestHandler : IRequestHandler<GetOrderedRequest, Result<List<Order>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly BasketAccessor _basketAccessor;

    public GetOrderedRequestHandler(IMapper mapper,IUnitOfWork unitOfWork,BasketAccessor basketAccessor)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _basketAccessor = basketAccessor;
    }
    public async Task<Result<List<Order>>> Handle(GetOrderedRequest request, CancellationToken cancellationToken)
    {
        var buyerId = _basketAccessor.GetAnounceBuyerId();
        if (buyerId == null) return Result<List<Order>>.Failure("your not logedIn");
        var orders = await _unitOfWork.OrderRepository.GetOreders(buyerId);
        return Result<List<Order>>.Success(orders);
    }
}
