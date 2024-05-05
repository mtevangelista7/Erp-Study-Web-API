using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Tests.Builders.Categories;
using ErpStudy.Application.UseCases.Categories;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using Moq;

namespace ErpStudy.Application.Tests.Unit.Categories.UseCases
{
    public class GetCategoryByIdUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_WithValidRequest_ShouldReturnOkResultWithCategory()
        {
            // Arrange
            var validRequest = new GetCategoryByIdDTOBuilder().Build();
            var category = new Category();
            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository.Setup(repo => repo.GetById(It.IsAny<Guid>())).ReturnsAsync(category);

            var useCase = new GetCategoryByIdUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ExecuteAsync(validRequest);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(category, result.Value);
        }

        [Fact]
        public async Task ExecuteAsync_WithInvalidRequest_ShouldReturnFailResultWithErrors()
        {
            // Arrange
            GetCategoryByIdDTO invalidRequest = new GetCategoryByIdDTOBuilder().WithId(Guid.Empty).Build();
            var mockRepository = new Mock<ICategoryRepository>();

            var useCase = new GetCategoryByIdUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ExecuteAsync(invalidRequest);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Errors);
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public async Task ExecuteAsync_WithRepositoryError_ShouldReturnFailResultWithErrorMessage()
        {
            // Arrange
            var validRequest = new GetCategoryByIdDTOBuilder().Build();
            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository.Setup(repo => repo.GetById(It.IsAny<Guid>()))
                .ThrowsAsync(new Exception("Repository Error"));

            var useCase = new GetCategoryByIdUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ExecuteAsync(validRequest);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Errors);
            Assert.Single(result.Errors);
            Assert.Equal("Repository Error", result.Errors.First().Message);
        }
    }
}