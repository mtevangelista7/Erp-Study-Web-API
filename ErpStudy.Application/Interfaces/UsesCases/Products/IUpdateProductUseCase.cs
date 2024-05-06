using ErpStudy.Application.DTOs.Products;
using ErpStudy.Application.UseCases.Products;
using ErpStudy.Domain.Entities;

namespace ErpStudy.Application.Interfaces.UsesCases.Products
{
    public interface IUpdateProductUseCase : IUseCase<UpdateProductDTO, Product>
    {
    }
}