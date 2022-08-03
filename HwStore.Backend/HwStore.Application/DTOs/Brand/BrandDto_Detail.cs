
using HwStore.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Brand
{
    public class BrandDto_Detail:BaseDto
    {
        public string? Name { get; set; }

        public IEnumerable<ProductDto_Base>? Products { get; set; }
    }
}
