using AutoMapper;
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
    public class RemoveBasketItemRequestHandler : IRequestHandler<RemoveBasketItemRequest, Result<Unit>>
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
        public async Task<Result<Unit>> Handle(RemoveBasketItemRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.Exist(x => x.Id == request.basketDto_Param.productId);
            if(!product)return Result<Unit>.Failure("productId is not valid"); 

            var validator = new BasketParamsValidator(_unitOfWork);
            var validateResult =await validator.ValidateAsync(request.basketDto_Param);
            if (!validateResult.IsValid)
            {
                return Result<Unit>.Failure(validateResult.Errors.Select(x => x.ErrorMessage).ToList());
            }
            var buyerId = _basketAccessor.GetBuyerId();
            var basket = await _unitOfWork.BasketRepository.GetBasket(buyerId);
            if (basket == null) return Result<Unit>.Failure("Basket NotFound");

            var mappedBasket = _mapper.Map<Basket>(basket);
            if (mappedBasket.BasketItems == null) return Result<Unit>.Failure("BaskeItemsIsEmpty");
            var existProduct = mappedBasket.BasketItems.FirstOrDefault(item => item.ProductId == request.basketDto_Param?.productId);
            if (existProduct == null) return Result<Unit>.Failure("Product Not Found");
            if (existProduct.QuantityInBasket > 1)
            {
                existProduct.QuantityInBasket -= request.basketDto_Param.quantity;
            }
            else if (existProduct.QuantityInBasket == 1|| request.basketDto_Param.quantity>existProduct.QuantityInBasket)
            {
                mappedBasket.BasketItems.Remove(existProduct);
            }
            await _unitOfWork.SaveAsync();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
