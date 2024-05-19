using ErpStudy.Application.DTOs.Products;
using FluentValidation;

namespace ErpStudy.Application.Validator.ProductDTOValidator
{
    public class DeleteProductDTOValidator : AbstractValidator<DeleteProductDTO>
    {
        public DeleteProductDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required");
        }
    }
}