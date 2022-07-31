using AutoMapper;
using FluentValidation.Results;
using HwStore.Application.DTOs.Product.Validators;
using HwStore.Application.Features.Products.Requests.Commands;
using MediatR;

namespace HwStore.Application.Features.Products.Handlers.Commands;

public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {

        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    async Task<Result<Unit>> IRequestHandler<CreateProductRequest, Result<Unit>>.Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductDtoValidator(_unitOfWork.ProductRepository);
        ValidationResult validationResult = await validator.ValidateAsync(request.Product);
        if (validationResult.IsValid == false)
        {
            return Result<Unit>
                .Failure(validationResult.Errors
                .Select(x => x.ErrorMessage).ToList());
        }
        var mappedPrdocut = _mapper.Map<Product>(request.Product);
        await _unitOfWork.ProductRepository.Add(mappedPrdocut);
        await _unitOfWork.SaveAsync();
        return Result<Unit>.Success(Unit.Value);
    }
}
