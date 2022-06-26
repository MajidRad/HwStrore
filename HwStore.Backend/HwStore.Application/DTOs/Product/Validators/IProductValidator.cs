using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Product.Validators
{
    public class IProductValidator : AbstractValidator<IProductDto>
    {
        private readonly IProductRepository _product;
        public IProductValidator(IProductRepository product)
        {
            _product = product;
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("{PropertyName} not allowed to empty")
                .Length(2, 50)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} length");


            RuleFor(p => p.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("{PropertyName} not allowed to empty")
                .Length(2, 250)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} length");

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} must greater or equl 0 ");

            RuleFor(p=>p.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} must greater or equl 0 ");

        }
        protected bool BeValidName(string name)
        {
            return name.All(char.IsLetter);
        }
    }
}
