using FluentValidation;

namespace HwStore.Application.DTOs.Basket.Validators;

public class RemoveBasketItmeValidator : AbstractValidator<BasketDto_Param>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveBasketItmeValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        Include(new BasketParamsValidator(_unitOfWork));

    }
}
