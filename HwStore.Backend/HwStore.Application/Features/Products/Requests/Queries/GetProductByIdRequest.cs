using HwStore.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Products.Requests.Queries
{
    public class GetProductByIdRequest:IRequest<ProductDto_Details>
    {
        public int Id { get; set; }
    }
}
