using ErpStudy.Application.Tests.Builders.Categories;
using ErpStudy.Application.Validator.CategoryDTOValidator;
using FluentValidation;

namespace ErpStudy.Application.Tests.Unit.Categories.Validators
{
    public class DeleteCategoryDTOValidatorTests
    {
        private readonly DeleteCategoryDTOValidator _deleteCategoryDtoValidator = new();

        [Fact]
        public async Task DeleteCategoryDTOValidator_Validate_ShouldReturnErrorWhenIdIsEmpty()
        {
            // Arrange
            var deleteCategoryDTO = new DeleteCategoryDTOBuilder().WithId(Guid.Empty).Build();

            // Act
            var result = await _deleteCategoryDtoValidator.ValidateAsync(deleteCategoryDTO);

            // Assert
            Assert.NotEmpty(result.Errors);
            Assert.Contains("Id is required", result.Errors.Select(x => x.ErrorMessage));
        }
    }
}