using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Tests.Builders.Categories;
using ErpStudy.Application.UseCases.Categories;
using ErpStudy.Infrastructure.Data.Repositories.Interfaces;
using Moq;

namespace ErpStudy.Application.Tests.Unit.Categories.UseCases
{
    public class DeleteCategoryUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_WithValidRequest_ShouldReturnOkResult()
        {
            // Arrange
            var validRequest = DeleteCategoryDTOBuilder.CreateFake();
            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository.Setup(repo => repo.DeleteCategoryAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            var useCase = new DeleteCategoryUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ExecuteAsync(validRequest);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ExecuteAsync_WithInvalidRequest_ShouldReturnFailResultWithErrors()
        {
            // Arrange
            var invalidRequest = new DeleteCategoryDTO(Guid.Empty);
            var mockRepository = new Mock<ICategoryRepository>();

            var useCase = new DeleteCategoryUseCase(mockRepository.Object);

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
            var validRequest = DeleteCategoryDTOBuilder.CreateFake();
            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository.Setup(repo => repo.DeleteCategoryAsync(It.IsAny<Guid>()))
                .ThrowsAsync(new Exception("Repository Error"));

            var useCase = new DeleteCategoryUseCase(mockRepository.Object);

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