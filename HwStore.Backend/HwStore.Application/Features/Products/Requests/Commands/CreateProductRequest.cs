
using HwStore.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Products.Requests.Commands
{
    public class CreateProductRequest:IRequest<Result<Unit>>
    {
        public ProductDto_Create Product { get; set; }
    }
}
