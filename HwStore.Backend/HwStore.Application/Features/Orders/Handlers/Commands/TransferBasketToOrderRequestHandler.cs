using AutoMapper;
using HwStore.Application.Features.Orders.Requests.Commands;
using HwStore.Domain.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Orders.Handlers.Commands;
public class TransferBasketToOrderRequestHandler : IRequestHandler<TransferBasketToOrderRequest, Result<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TransferBasketToOrderRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
  
   async Task<Result<Unit>> IRequestHandler<TransferBasketToOrderRequest, Result<Unit>>.Handle(TransferBasketToOrderRequest request, CancellationToken cancellationToken)
    {
        var items = new List<OrderItem>();
        foreach (var item in request.Basket.BasketItems)
        {
            var productItem = await _unitOfWork
                .ProductRepository
                .GetFirstOrDefault(x => x.Id == item.ProductId);


            var itemOrdered = new ProductItemOrdered
            {
                productId = productItem.Id,
                Name = productItem.Name,
                pictrureUrl ="",
            };
            var orderItem = new OrderItem()
            {
                ItemOrdered = itemOrdered,
                Price = productItem.Price,
                Quantity = item.Quantity,
            };
            items.Add(orderItem);
            productItem.Quantity -= item.Quantity;
        }
        var subtotal = items.Sum(x => x.Price * x.Quantity);
        var deliveryFee = subtotal > 1000 ? 0 : 500;
        var Order = new Order()
        {
            OrderItems = items,
            BuyerId = request.Basket.BuyerId,
            shippingAddress = request.OrderDto.ShippingAddress,
            Subtotal = subtotal,
            DeliveryFee = deliveryFee,
        };
        var mappedBsaket = _mapper.Map<Basket>(request.Basket);
        await _unitOfWork.OrderRepository.Add(Order);
        //_unitOfWork.BasketRepository.Remove(mappedBsaket);
        await _unitOfWork.SaveAsync();
        return Result<Unit>.Success(Unit.Value);
    }
}
