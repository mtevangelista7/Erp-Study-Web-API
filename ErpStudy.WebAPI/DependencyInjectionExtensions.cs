using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.Services;
using ErpStudy.Application.Interfaces.UsesCases.Categories;
using ErpStudy.Application.Interfaces.UsesCases.Products;
using ErpStudy.Application.Interfaces.UsesCases.Users;
using ErpStudy.Application.Services;
using ErpStudy.Application.UseCases.Categories;
using ErpStudy.Application.UseCases.Products;
using ErpStudy.Application.UseCases.Users;
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


            // TODO: Colocar isso em outro método, ou alterar o nome desse
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            return serviceCollection;
        }

        public static IServiceCollection AddProductsServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
            serviceCollection.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
            serviceCollection.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
            serviceCollection.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();

            return serviceCollection;
        }

        public static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
            serviceCollection.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
            serviceCollection.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
            serviceCollection.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            return serviceCollection;
        }

        public static IServiceCollection AddAuthServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
            return serviceCollection;
        }
    }
}