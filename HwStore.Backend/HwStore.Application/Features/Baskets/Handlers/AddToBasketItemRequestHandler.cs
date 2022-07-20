using AutoMapper;
using HwStore.Application.DTOs.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HwStore.Domain;
using Microsoft.AspNetCore.Http;
using HwStore.Application.Features.Baskets.Requsts.Commands;

namespace HwStore.Application.Features.Baskets.Handlers
{
    public class AddToBasketItemRequestHandler : IRequestHandler<AddToBasketItemRequest, Result<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BasketAccessor _basketAccessor;
        private readonly IHttpContextAccessor _httpContext;

        public AddToBasketItemRequestHandler(IMapper mapper, IUnitOfWork unitOfWork, BasketAccessor basketAccessor,IHttpContextAccessor httpContext)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _basketAccessor = basketAccessor;
            _httpContext = httpContext;
        }
        private Basket CreateBasket(string buyerId)
        {
            if (string.IsNullOrEmpty(buyerId))
            {
                buyerId = Guid.NewGuid().ToString();
                var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
                _httpContext.HttpContext.Response.Cookies.Append("buyerId", buyerId,cookieOptions);
            }
            var basket = new Basket { BuyerId = buyerId ,BasketItems=new()};
            _unitOfWork.BasketRepository.Add(basket);
            return basket;
        }
        public async Task<Result<Unit>> Handle(AddToBasketItemRequest request, CancellationToken cancellationToken)
        {
            var buyerId = _basketAccessor.GetBuyerId();
            var basket = await _unitOfWork.BasketRepository.GetBasket(buyerId);
            if (basket == null)
            {
                basket = CreateBasket(buyerId);
            }


            var product = await _unitOfWork.ProductRepository
                .GetFirstOrDefault(x => x.Id == request.prodcutId);
            if (basket.BasketItems.All(item => item.ProductId != request.prodcutId))
            {
                basket.BasketItems.Add(new BasketItem { Product = product, QuantityInBasket = request.quantity });
            }
            var existingItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == request.prodcutId);
            if (existingItem != null) existingItem.QuantityInBasket += request.quantity;
        
            await _unitOfWork.SaveAsync();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
