using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.UsesCases.Categories;
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
        public static IServiceCollection AddCategoryServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
            serviceCollection.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
            serviceCollection.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
            serviceCollection.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();


            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            return serviceCollection;
        }
    }
}