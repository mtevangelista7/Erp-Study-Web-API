using ErpStudy.Application.DTOs;
using ErpStudy.Application.DTOs.Categories;
using FluentValidation;

namespace ErpStudy.Application.Validator.CategoryDTOValidator
{
    public class UpdateCategoryDTOValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidator()
        {
            RuleFor(category => category.Id)
                .NotEmpty()
                .WithMessage("Id is required");

            RuleFor(category => category.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required");
        }
    }
}