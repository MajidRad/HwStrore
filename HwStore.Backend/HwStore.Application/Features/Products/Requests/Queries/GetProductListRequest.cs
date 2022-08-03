using HwStore.Application.Core;
using HwStore.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Products.Requests.Queries
{
    public class GetProductListRequest:IRequest<Result<PagedList<ProductDto_Base>>>
    {
        public ProductParams Params { get; set; }
    }
}
