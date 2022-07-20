using HwStore.Application.DTOs.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Baskets.Requsts.Commands
{
    public class AddToBasketItemRequest : IRequest<Result<Unit>>
    {
        public int prodcutId { get; set; }
        public int quantity { get; set; }
    }
}
