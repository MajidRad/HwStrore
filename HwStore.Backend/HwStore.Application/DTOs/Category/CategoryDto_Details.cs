using HwStore.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Category
{
    public class CategoryDto_Details:CategoryDto_Base
    {
        public IEnumerable<ProductDto_Base>? Products { get; set; }
    }
}
