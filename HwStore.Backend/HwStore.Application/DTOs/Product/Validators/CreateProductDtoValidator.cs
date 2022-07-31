using FluentValidation;

namespace HwStore.Application.DTOs.Product.Validators;

public class CreateProductDtoValidator : AbstractValidator<ProductDto_Create>
{
    private readonly IProductRepository _product;

    public CreateProductDtoValidator(IProductRepository product)
    {
        _product = product;
        Include(new IProductValidator(_product));
    }
}
