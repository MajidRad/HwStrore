using HwStore.Application.DTOs.Brand;
using HwStore.Application.DTOs.Category;
using HwStore.Application.DTOs.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Product
{
    public class ProductDto_Details:ProductDto_Base
    {
       
        public CategoryDto_Base? Category { get; set; }

        public BrandDto_Base? Brand { get; set; }

        public IEnumerable<ImageDto_Base>? Images { get; set; }

        public int DetailId { get; set; }
    }
}
