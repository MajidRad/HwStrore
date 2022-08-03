using HwStore.Application.DTOs.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Baskets.Requsts.Queries
{
    public class GetBasketRequest : IRequest<Result<BasketDto_Base>>
    {
        public string buyerId { get; set; }
    }
}
