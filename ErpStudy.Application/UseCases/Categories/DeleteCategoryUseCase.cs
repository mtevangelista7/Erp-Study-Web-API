using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.UsesCases.Categories;
using ErpStudy.Application.Validator.CategoryDTOValidator;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;
using FluentValidation.Results;

namespace ErpStudy.Application.UseCases.Categories
{
    public class DeleteCategoryUseCase(ICategoryRepository categoryRepository) : IDeleteCategoryUseCase
    {
        public async Task<Result> ExecuteAsync(DeleteCategoryDTO request)
        {
            try
            {
                ValidationResult validationResult = await new DeleteCategoryDTOValidator().ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> err = validationResult.Errors.Select(e => e.ErrorMessage);
                    return Result.Fail(err);
                }

                await categoryRepository.Delete(request.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}