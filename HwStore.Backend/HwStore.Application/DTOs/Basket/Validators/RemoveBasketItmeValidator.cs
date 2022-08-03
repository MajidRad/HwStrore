using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Basket.Validators
{
    public class RemoveBasketItmeValidator:AbstractValidator<BasketDto_Param> 
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveBasketItmeValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new BasketParamsValidator(_unitOfWork));
        
        }
    }
}
