using AutoMapper;
using HwStore.Application.DTOs.Basket;
using HwStore.Application.Features.Baskets.Requsts.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Baskets.Handlers
{
    public class GetBasketRequestHandler : IRequestHandler<GetBasketRequest, Result<BasketDto_Base>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetBasketRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<BasketDto_Base>> Handle(GetBasketRequest request, CancellationToken cancellationToken)
        {
            if (request.buyerId == null) return null;
            var basket = await _unitOfWork.BasketRepository.GetBasket(request.buyerId);
            var mappedBasket = _mapper.Map<BasketDto_Base>(basket);
            return Result<BasketDto_Base>.Success(mappedBasket);
        }
    }
}
