using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Tests.Builders.Categories;
using ErpStudy.Application.Validator.CategoryDTOValidator;
using FluentValidation.Results;

namespace ErpStudy.Application.Tests.Unit.Categories.Validators
{
    public class CreateCategoryDTOValidatorTests
    {
        private readonly CreateCategoryDTOValidator _validator = new();

        [Fact]
        public async Task CreateCategoryDTOValidator_Validate_ShouldReturnErrorWhenNameIsEmpty()
        {
            // Arrange
            CreateCategoryDTO createCategoryDTO = new CreateCategoryDTOBuilder().WithName("").Build();

            // Act
            ValidationResult? result = await _validator.ValidateAsync(createCategoryDTO);

            // Assert
            Assert.NotEmpty(result.Errors);
            Assert.Contains("Name is required.", result.Errors.Select(err => err.ErrorMessage));
        }
    }
}