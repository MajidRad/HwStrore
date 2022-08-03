using HwStore.Application.DTOs.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Baskets.Requsts.Commands
{
    public class RemoveBasketRequest:IRequest<Result<Unit>>
    {
       public string? BuyerId { get; set; }
    }
}
