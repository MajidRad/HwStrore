using AutoMapper;
using HwStore.Application.Contract.Persistence;
using HwStore.Application.Core;
using HwStore.Application.DTOs.Brand;
using HwStore.Application.Features.Brands.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Brands.Handlers.Queries
{
    public class GetBrandListRequestHandler : IRequestHandler<GetBrandListRequest, Result<List<BrandDto_Base>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBrandListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        async Task<Result<List<BrandDto_Base>>> IRequestHandler<GetBrandListRequest, Result<List<BrandDto_Base>>>.Handle(GetBrandListRequest request, CancellationToken cancellationToken)
        {
            var brands = await _unitOfWork.BrandRepository.GetListAsync();
            var mappedBrands = _mapper.Map<List<BrandDto_Base>>(brands);
            return Result<List<BrandDto_Base>>.Success(mappedBrands);
        }
    }
}
