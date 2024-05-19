using ErpStudy.Application.DTOs.Products;
using FluentValidation;

namespace ErpStudy.Application.Validator.ProductDTOValidator
{
    public class GetProductByIdDTOValidator : AbstractValidator<GetProductByIdDTO>
    {
        public GetProductByIdDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required");
        }
    }
}