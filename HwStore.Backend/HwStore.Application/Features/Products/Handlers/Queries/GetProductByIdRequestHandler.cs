using AutoMapper;
using HwStore.Application.Contract.Persistence;
using HwStore.Application.DTOs.Product;
using HwStore.Application.Features.Products.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Products.Handlers.Queries
{
    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, ProductDto_Details>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByIdRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductDto_Details> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetFirstOrDefault(x=>x.Id==request.Id,x=>x.Category,x=>x.Brand);
            var mappedProduct = _mapper.Map<ProductDto_Details>(product);
            return mappedProduct;

        }
    }
}
