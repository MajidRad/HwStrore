using AutoMapper;
using HwStore.Application.DTOs.Basket;
using HwStore.Application.Features.Baskets.Requsts.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Baskets.Handlers
{
    public class TransferBasketToUserRequestHandler : IRequestHandler<TransferBasketToUserRequest, Result<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BasketAccessor _basketAccessor;

        public TransferBasketToUserRequestHandler(IMapper mapper, IUnitOfWork unitOfWork, BasketAccessor basketAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _basketAccessor = basketAccessor;
        }

        public async Task<Result<Unit>> Handle(TransferBasketToUserRequest request, CancellationToken cancellationToken)
        {
         
            if (request.Basket == null) return Result<Unit>.Failure("Request is null");
            var userBasket = new BasketDto_Base()
            {
                Id = request.Basket.Id,
                BuyerId = request.buyerId,
                BasketItems = request.Basket.BasketItems
            };

            await _unitOfWork.BasketRepository.UpdateBasket(userBasket);
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
