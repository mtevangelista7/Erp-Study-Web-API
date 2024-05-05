using ErpStudy.Application.DTOs;
using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.UsesCases;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;

namespace ErpStudy.Application.UseCases.Categories
{
    public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // TODO: Procurar uma forma de melhorar isso, não faz sentido ter que passar null
        public async Task<Result<List<Category>>> ExecuteAsync(GetAllCategoriesDTO? request = null)
        {
            return Result.Ok(await _categoryRepository.GetAll());
        }
    }
}