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
    public class DeleteCategoryUseCase(ICategoryRepository categoryRepository) : IUseCase<DeleteCategoryDTO, Result>
    {
        public async Task<Result> ExecuteAsync(DeleteCategoryDTO request)
        {
            try
            {
                ValidationResult validationResult = await new DeleteCategoryDTOValidator().ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    var err = validationResult.Errors.Select(e => e.ErrorMessage);
                    return Result.Fail(err);
                }

                // chama o caso de para realizar a exlusão do categoria
                if (await categoryRepository.DeleteCategoryAsync(request.Id))
                {
                    return Result.Ok();
                }

                // TODO: Adicionar alguma mensagem ou ver outra forma de sinalizar que não conseguiu excluir
                return Result.Fail("");
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}