using ErpStudy.Application.Tests.Builders.Categories;
using ErpStudy.Application.Validator.CategoryDTOValidator;

namespace ErpStudy.Application.Tests.Unit.Categories.Validators
{
    public class GetCategoryByIdDTOValidatorTests
    {
        private readonly GetCategoryByIdDTOValidator _validator = new();

        [Fact]
        public async Task DeleteCategoryDTOValidator_Validate_ShouldReturnErrorWhenIdIsEmpty()
        {
            // Arrange
            var getCategoeryByIdDTO = new GetCategoryByIdDTOBuilder().WithId(Guid.Empty).Build();

            // Act
            var result = await _validator.ValidateAsync(getCategoeryByIdDTO);

            // Assert
            Assert.NotEmpty(result.Errors);
            Assert.Contains("Id is required", result.Errors.Select(x => x.ErrorMessage));
        }
    }
}