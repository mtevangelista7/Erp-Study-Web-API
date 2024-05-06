using ErpStudy.Application.DTOs.Products;
using ErpStudy.Domain.Entities;

namespace ErpStudy.Application.Interfaces.UsesCases.Products
{
    public interface IGetProductByIdUseCase : IUseCase<GetProductByIdDTO, Product>
    {
    }
}