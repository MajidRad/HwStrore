using HwStore.Application.Core;
using HwStore.Application.DTOs.Brand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Brands.Requests.Queries
{
    public class GetBrandListRequest:IRequest<Result<List<BrandDto_Base>>>
    {
    }
}
