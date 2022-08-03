using HwStore.Domain.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Orders.Requests.Queries;
public class GetOrderedRequest:IRequest<Result<List<Order>>>
{
    
}
