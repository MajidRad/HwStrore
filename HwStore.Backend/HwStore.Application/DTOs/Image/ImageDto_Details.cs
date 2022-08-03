using HwStore.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Image
{
    public class ImageDto_Details : ImageDto_Base
    {
        public int ProductId { get; set; }
        public ProductDto_Base? Product { get; set; }
    }
}
