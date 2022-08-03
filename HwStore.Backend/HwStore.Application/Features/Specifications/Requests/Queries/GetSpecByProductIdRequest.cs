using HwStore.Application.Core;
using HwStore.Application.DTOs.Specification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Specifications.Requests.Queries
{
    public class GetSpecByProductIdRequest:IRequest<Result<List<SpecificationDto_Base>>>
    {
        public int productId { get; set; }
    }
}
