using ErpStudy.Application.DTOs;
using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.UsesCases.Categories;
using ErpStudy.Application.Validator;
using ErpStudy.Application.Validator.CategoryDTOValidator;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;
using FluentValidation.Results;

namespace ErpStudy.Application.UseCases.Categories
{
    public class CreateCategoryUseCase(ICategoryRepository categoryRepository)
        : ICreateCategoryUseCase
    {
        public async Task<Result<Category>> ExecuteAsync(CreateCategoryDTO request)
        {
            try
            {
                ValidationResult validationResult = await new CreateCategoryDTOValidator().ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errors = validationResult.Errors.Select(err => err.ErrorMessage);
                    return Result.Fail(errors);
                }

                Category newCategory = new() { Name = request.Name };

                Category category = await categoryRepository.Add(newCategory);

                return Result.Ok(category)!;
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}