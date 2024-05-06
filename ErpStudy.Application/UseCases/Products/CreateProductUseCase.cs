using ErpStudy.Application.DTOs.Products;
using ErpStudy.Application.Interfaces.UsesCases.Products;
using ErpStudy.Application.Validator.ProductDTOValidator;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;

namespace ErpStudy.Application.UseCases.Products
{
    public class CreateProductUseCase(IProductRepository productRepository, ICategoryRepository categoryRepository)
        : ICreateProductUseCase
    {
        public async Task<Result<Product>> ExecuteAsync(CreateProductDTO request)
        {
            try
            {
                var validationResult = await new CreateProductDTOValidator().ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errors = validationResult.Errors.Select(err => err.ErrorMessage);
                    return Result.Fail(errors);
                }

                var category = await categoryRepository.GetById(request.CategoryId);

                if (category is null)
                {
                    return Result.Fail("Category not found");
                }

                Product newProduct = new()
                {
                    Name = request.Name,
                    SKUCode = request.SKUCode,
                    SalesPrice = request.SalesPrice,
                    Unity = request.Unity,
                    Condition = request.Condition,
                    Category = category
                };

                var product = await productRepository.Add(newProduct);
                return Result.Ok(product)!;
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}