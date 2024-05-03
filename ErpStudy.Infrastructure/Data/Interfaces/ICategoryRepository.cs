using ErpStudy.Domain.Entities;

namespace ErpStudy.Infrastructure.Data.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> CreateCategoryAsync(Category category);
    Task<bool> UpdateCategoryAsync(Category category);
    Task<Category?> GetCategoryByIdAsync(Guid id);
    Task<List<Category>> GetAllCategoriesAsync();
    Task<bool> DeleteCategoryAsync(Guid id);
}