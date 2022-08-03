using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Basket
{
    public class BasketDto_Update
    {
        public string? BuyerId { get; set; } = null!;
        public List<BasketItemDto>? BasketItems { get; set; } = new List<BasketItemDto>();
    }
}
