using ErpStudy.Application.DTOs.Products;
using ErpStudy.Application.Interfaces.UsesCases.Products;
using ErpStudy.Application.Validator.ProductDTOValidator;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;

namespace ErpStudy.Application.UseCases.Products
{
    public class GetProductByIdUseCase(IProductRepository productRepository) : IGetProductByIdUseCase
    {
        public async Task<Result<Product>> ExecuteAsync(GetProductByIdDTO request)
        {
            try
            {
                var validationResult = await new GetProductByIdDTOValidator().ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errors = validationResult.Errors.Select(err => err.ErrorMessage);
                    return Result.Fail(errors);
                }

                var product = await productRepository.GetById(request.Id);
                return Result.Ok(product);
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}