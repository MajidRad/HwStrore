using FluentValidation;

namespace HwStore.Application.DTOs.Product.Validators;

public class UpdateProductDtoValidator : AbstractValidator<ProductDto_Base>
{
    private readonly IProductRepository _product;

    public UpdateProductDtoValidator(IProductRepository product)
    {
        _product = product;
        Include(new IProductValidator(_product));
    }
}
