using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.UsesCases;
using ErpStudy.Application.UseCases.Categories;
using ErpStudy.Application.Validator.CategoryDTOValidator;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using ErpStudy.Infrastructure.Data.Repositories;
using FluentResults;

namespace ErpStudy.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddCategoryUseCases(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUseCase<CreateCategoryDTO, Result<Category>>, CreateCategoryUseCase>();
            serviceCollection.AddSingleton<CreateCategoryDTOValidator>();
            return serviceCollection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            return serviceCollection;
        }
    }
}