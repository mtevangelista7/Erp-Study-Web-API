using ErpStudy.Application.DTOs.Products;
using ErpStudy.Application.Interfaces.UsesCases.Products;
using ErpStudy.Application.Validator.ProductDTOValidator;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;

namespace ErpStudy.Application.UseCases.Products
{
    public class DeleteProductUseCase(IProductRepository productRepository) : IDeleteProductUseCase
    {
        public async Task<Result> ExecuteAsync(DeleteProductDTO request)
        {
            try
            {
                var validationResult = await new DeleteProductDTOValidator().ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errors = validationResult.Errors.Select(err => err.ErrorMessage);
                    return Result.Fail(errors);
                }

                var product = productRepository.GetById(request.Id);

                if (product is null)
                {
                    return Result.Fail("Product not found");
                }

                await productRepository.Delete(request.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}