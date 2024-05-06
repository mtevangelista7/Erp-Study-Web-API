using ErpStudy.Application.Interfaces.UsesCases.Categories;
using ErpStudy.Application.Interfaces.UsesCases.Products;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;

namespace ErpStudy.Application.UseCases.Products
{
    public class GetAllProductsUseCase(IProductRepository productRepository) : IGetAllProductsUseCase
    {
        public async Task<Result<List<Product>>> ExecuteAsync()
        {
            try
            {
                return Result.Ok(await productRepository.GetAll());
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}