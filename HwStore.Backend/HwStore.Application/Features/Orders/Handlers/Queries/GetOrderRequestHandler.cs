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
public class GetOrderRequestHandler : IRequestHandler<GetOrderRequest, Result<Order>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderRequestHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    async Task<Result<Order>> IRequestHandler<GetOrderRequest, Result<Order>>.Handle(GetOrderRequest request, CancellationToken cancellationToken)
    {
        var order =await _unitOfWork.OrderRepository.GetFirstOrDefault(x => x.Id == request.OrderId,q=>q.OrderItems);
        return Result<Order>.Success(order);
    }
}
