using ErpStudy.Application.DTOs;
using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.UsesCases.Categories;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;

namespace ErpStudy.Application.UseCases.Categories
{
    public class GetAllCategoriesUseCase(ICategoryRepository categoryRepository) : IGetAllCategoriesUseCase
    {
        public async Task<Result<List<Category>>> ExecuteAsync()
        {
            try
            {
                return Result.Ok(await categoryRepository.GetAll());
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}