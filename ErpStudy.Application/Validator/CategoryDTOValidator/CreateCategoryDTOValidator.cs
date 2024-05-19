using ErpStudy.Application.DTOs;
using ErpStudy.Application.DTOs.Categories;
using FluentValidation;

namespace ErpStudy.Application.Validator.CategoryDTOValidator
{
    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(category => category.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required");
        }
    }
}