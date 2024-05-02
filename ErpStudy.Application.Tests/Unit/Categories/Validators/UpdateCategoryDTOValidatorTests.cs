using ErpStudy.Application.Tests.Builders.Categories;
using ErpStudy.Application.Validator.CategoryDTOValidator;

namespace ErpStudy.Application.Tests.Unit.Categories.Validators
{
    public class UpdateCategoryDTOValidatorTests
    {
        private readonly UpdateCategoryDTOValidator _validatorTests = new();

        [Fact]
        public async Task UpdateCategoryDTOValidator_Validate_ShouldReturnErrorWhenNameIsEmpty()
        {
            // Arrange
            var updateCategoryDTO = new UpdateCategoryDTOBuilder().WithName("").Build();

            // Act
            var result = await _validatorTests.ValidateAsync(updateCategoryDTO);

            // Assert
            Assert.NotEmpty(result.Errors);
            Assert.Contains("Name is required.", result.Errors.Select(err => err.ErrorMessage));
        }

        [Fact]
        public async Task UpdateCategoryDTOValidator_Validate_ShouldReturnErrorWhenIdIsEmpty()
        {
            // Arrange
            var updateCategoryDTO = new UpdateCategoryDTOBuilder().WithId(Guid.Empty).Build();

            // Act
            var result = await _validatorTests.ValidateAsync(updateCategoryDTO);

            // Assert
            Assert.NotEmpty(result.Errors);
            Assert.Contains("Id is required.", result.Errors.Select(err => err.ErrorMessage));
        }
    }
}