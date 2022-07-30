using AutoMapper;
using HwStore.Application.DTOs.Basket;
using HwStore.Application.DTOs.Basket.Validators;
using HwStore.Application.Features.Baskets.Requsts.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Baskets.Handlers
{
    public class RemoveBasketItemRequestHandler : IRequestHandler<RemoveBasketItemRequest, Result<BasketDto_Base>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BasketAccessor _basketAccessor;


        public RemoveBasketItemRequestHandler(IMapper mapper, IUnitOfWork unitOfWork, BasketAccessor basketAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _basketAccessor = basketAccessor;
        }


        async Task<Result<BasketDto_Base>> IRequestHandler<RemoveBasketItemRequest, Result<BasketDto_Base>>.Handle(RemoveBasketItemRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.Exist(x => x.Id == request.basketDto_Param.productId);
            if (!product) return Result<BasketDto_Base>.Failure("productId is not valid");

          
            var buyerId = _basketAccessor.GetBuyerId();
            var basket = await _unitOfWork.BasketRepository.GetBasket(buyerId);
            if (basket == null) return Result<BasketDto_Base>.Failure("Basket NotFound");

            var mappedBasket = _mapper.Map<Basket>(basket);
            if (mappedBasket.BasketItems == null) return Result<BasketDto_Base>.Failure("BaskeItemsIsEmpty");

            var existProduct = mappedBasket.BasketItems.FirstOrDefault(item => item.ProductId == request.basketDto_Param?.productId);
            if (existProduct == null) return Result<BasketDto_Base>.Failure("Product Not Found"); mappedBasket.BasketItems.Remove(existProduct);

            await _unitOfWork.SaveAsync();
            var mappedToBasketDto = _mapper.Map<BasketDto_Base>(mappedBasket);
            return Result<BasketDto_Base>.Success(mappedToBasketDto);
        }
    }
}
