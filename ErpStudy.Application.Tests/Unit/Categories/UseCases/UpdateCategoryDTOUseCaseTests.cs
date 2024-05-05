using ErpStudy.Application.Tests.Builders.Categories;
using ErpStudy.Application.UseCases.Categories;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using Moq;

namespace ErpStudy.Application.Tests.Unit.Categories.UseCases
{
    public class UpdateCategoryDTOUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_WithValidRequest_ShouldReturnOkResult()
        {
            // Arrange
            var validRequest = UpdateCategoryDTOBuilder.CreateFake();
            var category = new Category();
            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository.Setup(repo => repo.GetById(It.IsAny<Guid>())).ReturnsAsync(category);
            mockRepository.Setup(repo => repo.Update(It.IsAny<Category>())).ReturnsAsync(category);

            var useCase = new UpdateCategoryDTOUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ExecuteAsync(validRequest);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ExecuteAsync_WithInvalidRequest_ShouldReturnFailResultWithErrors()
        {
            // Arrange
            var invalidRequest = new UpdateCategoryDTOBuilder().WithId(Guid.Empty).WithName("").Build();
            var mockRepository = new Mock<ICategoryRepository>();

            var useCase = new UpdateCategoryDTOUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ExecuteAsync(invalidRequest);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Errors);
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public async Task ExecuteAsync_WithCategoryNotFound_ShouldReturnFailResult()
        {
            // Arrange
            var validRequest = UpdateCategoryDTOBuilder.CreateFake();
            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository.Setup(repo => repo.GetById(It.IsAny<Guid>())).ReturnsAsync((Category)null);

            var useCase = new UpdateCategoryDTOUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ExecuteAsync(validRequest);

            // Assert
            Assert.False(result.IsSuccess);
        }
    }
}