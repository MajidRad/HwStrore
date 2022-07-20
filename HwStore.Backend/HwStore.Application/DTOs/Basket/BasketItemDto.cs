using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Basket
{
    public class BasketItemDto
    {
        public int QuantityInBasket { get; set; }
        //public int ProductId { get; set; }
        //public ProductDto_Base Product { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

    }
}
