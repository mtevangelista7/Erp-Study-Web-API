using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Help;
using ErpStudy.Application.Interfaces.UsesCases;
using ErpStudy.Application.Tests.Builders.Categories;
using ErpStudy.Application.UseCases.Categories;
using ErpStudy.Domain.Entities;
using ErpStudy.WebAPI.Controllers;
using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Moq;
using ValidationFailure = FluentValidation.Results.ValidationFailure;

namespace ErpStudy.WebAPI.Tests.Unit.Controllers
{
    public class CategoryControllerTests(
        Mock<IUseCase<CreateCategoryDTO, Result<Category>>> createCategoryUseCase,
        Mock<IUseCase<DeleteCategoryDTO, Result<Category>>> deleteCategoryUseCase,
        Mock<IUseCase<GetAllCategoriesDTO, Result<List<Category>>>> getAllCategoriesUseCase,
        Mock<IUseCase<GetCategoryByIdDTO, Result<Category>>> getCategoryByIdUseCase,
        Mock<IUseCase<UpdateCategoryDTO, Result<Category>>> updateCategoryUseCase,
        Mock<ILogger<CategoryController>> logger)
    {
        // CREATE

        [Fact]
        public async Task AddCategory_ValidCategory_Returns201Created()
        {
            // Arrange
            var categoryDTO = CreateCategoryDTOBuilder.CreateFake();
            createCategoryUseCase.Setup(useCase => useCase.ExecuteAsync(It.IsAny<CreateCategoryDTO>()))
                .ReturnsAsync(new Result<Category>());

            CategoryController categoryController =
                new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
                    getCategoryByIdUseCase.Object,
                    updateCategoryUseCase.Object, logger.Object);

            // Act
            CreatedResult? result = await categoryController.AddCategory(categoryDTO) as CreatedResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal("AddCategory", result.Location);
            Assert.Equal(categoryDTO, result.Value);
        }

        [Fact]
        public async Task AddCategory_InvalidCategory_Returns400BadRequestWithErrors()
        {
            // Arrange
            var categoryDTO = new CreateCategoryDTOBuilder().WithName(null).Build();
            createCategoryUseCase.Setup(useCase => useCase.ExecuteAsync(It.IsAny<CreateCategoryDTO>()))
                .ReturnsAsync(Result.Fail<Category>(new List<string> { "Err 1", "Err 2" }));

            CategoryController categoryController =
                new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
                    getCategoryByIdUseCase.Object,
                    updateCategoryUseCase.Object, logger.Object);

            // Act
            IActionResult result = await categoryController.AddCategory(categoryDTO);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.IsType<List<string>>(badRequestResult.Value);
            var errors = badRequestResult.Value as List<string>;
            Assert.Contains("Err 1", errors);
            Assert.Contains("Err 2", errors);
        }

        [Fact]
        public async Task AddCategory_ExceptionThrown_Returns500InternalServerError()
        {
            // Arrange
            var categoryDTO = CreateCategoryDTOBuilder.CreateFake();
            const string msgErr = Helper.MessageInfo.ErroTentarCadastrarRecurso;
            createCategoryUseCase.Setup(useCase => useCase.ExecuteAsync(It.IsAny<CreateCategoryDTO>()))
                .ThrowsAsync(new Exception(msgErr));

            CategoryController categoryController =
                new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
                    getCategoryByIdUseCase.Object,
                    updateCategoryUseCase.Object, logger.Object);

            // Act
            ObjectResult? result = await categoryController.AddCategory(categoryDTO) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal(msgErr, result.Value);
        }

        // END CREATE

        // READ

        [Fact]
        public async Task GetCategoryById_Returns_OK_When_Successful()
        {
            // Arrange
            var getCategoryById = new GetCategoryByIdDTOBuilder().WithId(Guid.NewGuid()).Build();
            var category = new Category { Id = getCategoryById.Id, Name = "Apagar - Teste" };
            getCategoryByIdUseCase.Setup(useCase => useCase.ExecuteAsync(getCategoryById))
                .ReturnsAsync(new Result<Category>().WithValue(category));

            CategoryController categoryController =
                new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
                    getCategoryByIdUseCase.Object,
                    updateCategoryUseCase.Object, logger.Object);

            // Act
            var result = await categoryController.GetCategoryById(getCategoryById);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(category, okResult.Value);
        }

        [Fact]
        public async Task GetCategoryById_Returns_NotFound_When_Failed()
        {
            // Arrange
            var getCategoryById = new GetCategoryByIdDTOBuilder().WithId(Guid.NewGuid()).Build();
            var error = "Category not found";
            var failedResult = new Result<Category>().WithError(error);
            getCategoryByIdUseCase.Setup(x => x.ExecuteAsync(getCategoryById)).ReturnsAsync(failedResult);

            CategoryController categoryController =
                new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
                    getCategoryByIdUseCase.Object,
                    updateCategoryUseCase.Object, logger.Object);

            // Act
            var result = await categoryController.GetCategoryById(getCategoryById);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(error, notFoundResult.Value);
        }

        [Fact]
        public async Task GetCategoryById_Returns_InternalServerError_When_Exception()
        {
            // Arrange
            var getCategoryById = new GetCategoryByIdDTOBuilder().WithId(Guid.NewGuid()).Build();
            getCategoryByIdUseCase.Setup(x => x.ExecuteAsync(getCategoryById))
                .ThrowsAsync(new Exception("Some exception"));

            CategoryController categoryController =
                new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
                    getCategoryByIdUseCase.Object,
                    updateCategoryUseCase.Object, logger.Object);

            // Act
            var result = await categoryController.GetCategoryById(getCategoryById);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAllCategories_Returns_OK_When_Successful()
        {
            // Arrange
            var categories = new List<Category> { new Category { } };

            getAllCategoriesUseCase.Setup(x => x.ExecuteAsync(null))
                .ReturnsAsync(categories);

            CategoryController categoryController =
                new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
                    getCategoryByIdUseCase.Object,
                    updateCategoryUseCase.Object, logger.Object);
            // Act
            var result = await categoryController.GetAllCategories();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCategories = Assert.IsAssignableFrom<IEnumerable<Category>>(okResult.Value);
            Assert.Equal(categories, returnedCategories);
        }

        [Fact]
        public async Task GetAllCategories_Returns_InternalServerError_When_Exception()
        {
            // Arrange
            getAllCategoriesUseCase.Setup(x => x.ExecuteAsync(null)).ThrowsAsync(new Exception("Some exception"));

            CategoryController categoryController =
                new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
                    getCategoryByIdUseCase.Object,
                    updateCategoryUseCase.Object, logger.Object);

            // Act
            var result = await categoryController.GetAllCategories();

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        // END READ

        // UPDATE

        [Fact]
        public async Task UpdateCategory_Returns_OK_When_Successful()
        {
            // Arrange
            var category = UpdateCategoryDTOBuilder.CreateFake();
            var validationResult = new ValidationResult();
            updateCategoryUseCase.Setup(x => x.ExecuteAsync(category)).ReturnsAsync(
                new Result<Category> { });

            CategoryController categoryController =
    new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
        getCategoryByIdUseCase.Object,
        updateCategoryUseCase.Object, logger.Object);


            // Act
            var result = await categoryController.UpdateCategory(category);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(category, okResult.Value);
        }

        [Fact]
        public async Task UpdateCategory_Returns_BadRequest_When_Validation_Fails()
        {
            // Arrange
            var category = UpdateCategoryDTOBuilder.CreateFake();
            var validationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("propertyName", "errorMessage") });

            // Mock validation failure
            var validatorMock = new Mock<IValidator<UpdateCategoryDTO>>();
            validatorMock.Setup(x => x.ValidateAsync(category, default)).ReturnsAsync(validationResult);

            CategoryController categoryController =
new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
getCategoryByIdUseCase.Object,
updateCategoryUseCase.Object, logger.Object);

            // Act
            var result = await categoryController.UpdateCategory(category);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(validationResult.Errors, badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateCategory_Returns_NotFound_When_Failed()
        {
            // Arrange
            var category = UpdateCategoryDTOBuilder.CreateFake();
            var failedResult = new Result<Category>().WithError("Category not found");

            updateCategoryUseCase.Setup(x => x.ExecuteAsync(category)).ReturnsAsync(failedResult);


            CategoryController categoryController =
new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
getCategoryByIdUseCase.Object,
updateCategoryUseCase.Object, logger.Object);

            // Act
            var result = await categoryController.UpdateCategory(category);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(failedResult.Errors, notFoundResult.Value);
        }

        [Fact]
        public async Task UpdateCategory_Returns_InternalServerError_When_Exception()
        {
            // Arrange
            var category = UpdateCategoryDTOBuilder.CreateFake();
            updateCategoryUseCase.Setup(x => x.ExecuteAsync(category)).ThrowsAsync(new Exception("Some exception"));

            CategoryController categoryController =
new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
getCategoryByIdUseCase.Object,
updateCategoryUseCase.Object, logger.Object);

            // Act
            var result = await categoryController.UpdateCategory(category);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        // END UPDATE

        // DELETE
        [Fact]
        public async Task DeleteCategory_Returns_NoContent_When_Successful()
        {
            // Arrange
            var id = DeleteCategoryDTOBuilder.CreateFake();
            var validationResult = new ValidationResult();
            var successfulResult = new Result<Category>();

            deleteCategoryUseCase.Setup(useCase => useCase.ExecuteAsync(id)).ReturnsAsync(successfulResult);

            CategoryController categoryController =
new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
getCategoryByIdUseCase.Object,
updateCategoryUseCase.Object, logger.Object);

            // Act
            var result = await categoryController.DeleteCategory(id);

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContentResult.StatusCode);
        }

        [Fact]
        public async Task DeleteCategory_Returns_BadRequest_When_Validation_Fails()
        {
            // Arrange
            var id = DeleteCategoryDTOBuilder.CreateFake();
            var validationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("propertyName", "errorMessage") });

            // Mock validation failure
            var validatorMock = new Mock<IValidator<DeleteCategoryDTO>>();
            validatorMock.Setup(x => x.ValidateAsync(id, default)).ReturnsAsync(validationResult);

            CategoryController categoryController =
new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
getCategoryByIdUseCase.Object,
updateCategoryUseCase.Object, logger.Object);

            // Act
            var result = await categoryController.DeleteCategory(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(validationResult.Errors, badRequestResult.Value);
        }

        [Fact]
        public async Task DeleteCategory_Returns_NotFound_When_Failed()
        {
            // Arrange
            var id = DeleteCategoryDTOBuilder.CreateFake();
            var failedResult = new Result<Category>().WithError("Category not found");

            deleteCategoryUseCase.Setup(x => x.ExecuteAsync(id)).ReturnsAsync(failedResult);

            CategoryController categoryController =
new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
getCategoryByIdUseCase.Object,
updateCategoryUseCase.Object, logger.Object);

            // Act
            var result = await categoryController.DeleteCategory(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(failedResult.Errors, notFoundResult.Value);
        }

        [Fact]
        public async Task DeleteCategory_Returns_InternalServerError_When_Exception()
        {
            // Arrange
            var id = DeleteCategoryDTOBuilder.CreateFake();
            deleteCategoryUseCase.Setup(x => x.ExecuteAsync(id)).ThrowsAsync(new Exception("Some exception"));

            CategoryController categoryController =
new(createCategoryUseCase.Object, deleteCategoryUseCase.Object, getAllCategoriesUseCase.Object,
getCategoryByIdUseCase.Object,
updateCategoryUseCase.Object, logger.Object);

            // Act
            var result = await categoryController.DeleteCategory(id);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        // END DELETE
    }
}