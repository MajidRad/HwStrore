using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Product
{
    public class ProductDto_Base:BaseDto,IProductDto
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public List<ImageDto_Base>? Images { get; set; }
    }
}
