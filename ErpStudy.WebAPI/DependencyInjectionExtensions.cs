using ErpStudy.Application.DTOs;
using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.UsesCases;
using ErpStudy.Application.UseCases.Categories;
using ErpStudy.Application.Validator;
using ErpStudy.Application.Validator.CategoryDTOValidator;
using ErpStudy.Domain.Entities;
using FluentResults;

namespace ErpStudy.WebAPI
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCategoryUseCases(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUseCase<CreateCategoryDTO, Result<Category>>, CreateCategoryUseCase>();
            serviceCollection.AddSingleton<CreateCategoryDTOValidator>();
            return serviceCollection;
        }
    }
}