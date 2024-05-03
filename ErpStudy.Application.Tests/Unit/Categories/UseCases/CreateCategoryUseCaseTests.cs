using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Tests.Builders.Categories;
using ErpStudy.Application.UseCases.Categories;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;
using Moq;

namespace ErpStudy.Application.Tests.Unit.Categories.UseCases
{
    public class CreateCategoryUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_WithValidRequest_ShouldReturnOkResultWithCategory()
        {
            // Arrange
            CreateCategoryDTO validRequest = CreateCategoryDTOBuilder.CreateFake();

            Mock<ICategoryRepository> mockRepository = new();
            mockRepository.Setup(repo => repo.CreateCategoryAsync(It.IsAny<Category>())).ReturnsAsync(new Category());

            CreateCategoryUseCase useCase = new(mockRepository.Object);

            // Act
            Result<Category> result = await useCase.ExecuteAsync(validRequest);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.IsType<Category>(result.Value);
        }

        [Fact]
        public async Task ExecuteAsync_WithInvalidRequest_ShouldReturnFailResultWithErrors()
        {
            // Arrange
            CreateCategoryDTO invalidRequest = new CreateCategoryDTOBuilder().WithName(null!).Build();
            Mock<ICategoryRepository> mockRepository = new();

            CreateCategoryUseCase useCase = new(mockRepository.Object);

            // Act
            Result<Category?> result = await useCase.ExecuteAsync(invalidRequest);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Errors);
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public async Task ExecuteAsync_WithRepositoryError_ShouldReturnFailResultWithErrorMessage()
        {
            // Arrange
            CreateCategoryDTO validRequest = CreateCategoryDTOBuilder.CreateFake();
            Mock<ICategoryRepository> mockRepository = new();
            mockRepository.Setup(repo => repo.CreateCategoryAsync(It.IsAny<Category>()))
                .ThrowsAsync(new Exception("Repository Error"));

            CreateCategoryUseCase useCase = new(mockRepository.Object);

            // Act
            Result<Category?> result = await useCase.ExecuteAsync(validRequest);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Errors);
            Assert.Single(result.Errors);
            Assert.Equal("Repository Error", result.Errors.First().Message);
        }
    }
}