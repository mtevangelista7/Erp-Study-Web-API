using ErpStudy.Application.DTOs;
using ErpStudy.Application.DTOs.Categories;
using FluentValidation;

namespace ErpStudy.Application.Validator.CategoryDTOValidator
{
    public class DeleteCategoryDTOValidator : AbstractValidator<DeleteCategoryDTO>
    {
        public DeleteCategoryDTOValidator()
        {
            RuleFor(category => category.Id)
                .NotEmpty()
                .WithMessage("Id is required");
        }
    }
}