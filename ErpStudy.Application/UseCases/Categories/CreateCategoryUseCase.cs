using ErpStudy.Application.DTOs;
using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.UsesCases;
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

                // verifica se o resultado é válido
                if (!validationResult.IsValid)
                {
                    // Caso não, realiza o log e devolve os erros
                    // TODO: Adicionar o armazenamento de logs
                    IEnumerable<string> errors = validationResult.Errors.Select(err => err.ErrorMessage);
                    return Result.Fail(errors);
                }

                // Todo: usar automapper?
                var newCategory = new Category() { Name = request.Name };

                // chama o repository que registra a categoria no banco
                var category = await categoryRepository.Add(newCategory);

                // retorna ok com o objeto criado
                return Result.Ok(category)!;
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}