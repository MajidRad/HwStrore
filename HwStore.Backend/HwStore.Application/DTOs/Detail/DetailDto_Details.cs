using HwStore.Application.DTOs.Brand;
using HwStore.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Detail
{
    public class DetailDto_Details : DetailDto_Base
    {
        public int ProductId { get; set; }
        public ProductDto_Base? Product { get; set; }
    }
}
