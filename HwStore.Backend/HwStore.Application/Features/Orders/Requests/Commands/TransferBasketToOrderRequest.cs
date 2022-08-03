using HwStore.Application.DTOs.Basket;
using HwStore.Application.DTOs.Order;
using HwStore.Domain.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Orders.Requests.Commands;
public class TransferBasketToOrderRequest:IRequest<Result<Unit>>
{
    public BasketDto_Base? Basket { get; set; }
    public OrderDto_Create OrderDto { get; set; }
}
