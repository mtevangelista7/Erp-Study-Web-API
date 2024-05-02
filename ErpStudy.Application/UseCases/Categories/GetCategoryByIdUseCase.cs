using ErpStudy.Application.DTOs;
using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.UsesCases;
using ErpStudy.Application.Validator.CategoryDTOValidator;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Repositories.Interfaces;
using FluentResults;
using FluentValidation.Results;

namespace ErpStudy.Application.UseCases.Categories
{
    public class GetCategoryByIdUseCase : IUseCase<GetCategoryByIdDTO, Result<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Category>> ExecuteAsync(GetCategoryByIdDTO request)
        {
            try
            {
                ValidationResult validationResult = await new GetCategoryByIdDTOValidator().ValidateAsync(request);

                if (validationResult.IsValid)
                {
                    // busca a categoria na base pelo ID
                    return Result.Ok(await _categoryRepository.GetCategoryByIdAsync(request.Id))!;
                }

                IEnumerable<string> err = validationResult.Errors.Select(e => e.ErrorMessage);
                return Result.Fail(err);
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}