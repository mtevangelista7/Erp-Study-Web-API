using ErpStudy.Application.UseCases.Categories;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using Moq;

namespace ErpStudy.Application.Tests.Unit.Categories.UseCases
{
    public class GetAllCategoriesUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_ShouldReturnListOfCategories()
        {
            // Arrange
            var categories = new List<Category> { new(), new() };
            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(categories);

            var useCase = new GetAllCategoriesUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ExecuteAsync();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(categories, result.Value);
        }
    }
}