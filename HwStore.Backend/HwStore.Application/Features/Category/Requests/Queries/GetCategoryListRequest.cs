using HwStore.Application.Core;
using HwStore.Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Category.Requests.Queries
{
    public class GetCategoryListRequest:IRequest<Result<List<CategoryDto_Base>>>
    {
    }
}
