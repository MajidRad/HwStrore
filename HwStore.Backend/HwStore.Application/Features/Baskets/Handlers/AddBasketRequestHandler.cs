using AutoMapper;
using HwStore.Application.Features.Baskets.Requsts.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Features.Baskets.Handlers
{
    public class AddBasketRequestHandler : IRequestHandler<AddBasketRequest, Result<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddBasketRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Unit>> Handle(AddBasketRequest request, CancellationToken cancellationToken)
        {
            var basket = _mapper.Map<Basket>(request.Basket);
            await _unitOfWork.BasketRepository.Add(basket);
            await _unitOfWork.SaveAsync();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
