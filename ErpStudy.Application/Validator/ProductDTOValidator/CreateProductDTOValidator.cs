using ErpStudy.Application.DTOs.Products;
using FluentValidation;

namespace ErpStudy.Application.Validator.ProductDTOValidator
{
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(product => product.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(250)
                .WithMessage("Up to 250 character limit");

            RuleFor(product => product.SalesPrice)
                .GreaterThanOrEqualTo(0);

            RuleFor(product => product.Unity)
                .IsInEnum()
                .WithMessage("Invalid unity");

            RuleFor(product => product.Condition)
                .IsInEnum()
                .WithMessage("Invalid condition");

            RuleFor(product => product.CategoryId)
                .NotEmpty()
                .WithMessage("Category is required");
        }
    }
}