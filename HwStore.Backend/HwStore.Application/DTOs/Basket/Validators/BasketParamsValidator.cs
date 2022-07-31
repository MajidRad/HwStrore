using FluentValidation;

namespace HwStore.Application.DTOs.Basket.Validators;

public class BasketParamsValidator : AbstractValidator<BasketDto_Param>
{
    private readonly IUnitOfWork _unitOfWork;

    public BasketParamsValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        RuleFor(b => b.productId).NotEmpty();
        RuleFor(b => b.quantity)
            .NotEmpty()
            .GreaterThanOrEqualTo(1).WithMessage("Quantity must be greater than zero");

        RuleFor(b => b)
            .NotEmpty()
            .MustAsync(async (b, token) =>
        {
            var product = await _unitOfWork.ProductRepository
            .GetFirstOrDefault(x => x.Id == b.productId);
            if (b.quantity <= product.Quantity) return true;
            return false;
        }).WithMessage("{PropertyName} must be less than or equal Stock quantity ");

    }
}
