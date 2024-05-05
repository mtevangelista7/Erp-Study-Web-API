using ErpStudy.Application.DTOs;
using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.UsesCases.Categories;
using ErpStudy.Application.Validator.CategoryDTOValidator;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;
using FluentValidation.Results;

namespace ErpStudy.Application.UseCases.Categories
{
    public class UpdateCategoryUseCase : IUpdateCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Category>> ExecuteAsync(UpdateCategoryDTO request)
        {
            ValidationResult validationResult = await new UpdateCategoryDTOValidator().ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var err = validationResult.Errors.Select(e => e.ErrorMessage);
                return Result.Fail(err);
            }

            // realiza a busca da categoria na base antes de tentar atualizar
            Category? category = await _categoryRepository.GetById(request.Id);

            if (category is null)
            {
                // TODO: Adicionar uma mensagem
                return Result.Fail("");
            }

            // Cria a nova categoria com os novos dados
            Category newCategory = new() { Name = request.Name ?? category.Name };

            // Atualiza e retorna ok
            await _categoryRepository.Update(newCategory);
            return Result.Ok();
        }
    }
}