using HwStore.Application.DTOs.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Baskets.Requsts.Commands
{
    public class UpdateBasketRequest:IRequest<Result<BasketDto_Base>>
    {
        public string? buyerId { get; set; }
        public BasketDto_Param? Params { get; set; }
    }
}
