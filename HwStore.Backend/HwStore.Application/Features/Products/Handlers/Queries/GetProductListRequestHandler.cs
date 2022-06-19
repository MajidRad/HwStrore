using AutoMapper;
using HwStore.Application.Contract.Persistence;
using HwStore.Application.DTOs.Product;
using HwStore.Application.Features.Products.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Products.Handlers.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductDto_Base>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProductDto_Base>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetListAsync();
            var mappedProducts = _mapper.Map<List<ProductDto_Base>>(products);
            return mappedProducts;
        }
    }
}
