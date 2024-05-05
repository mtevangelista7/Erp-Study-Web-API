//using ErpStudy.Application.DTOs.Categories;
//using ErpStudy.Application.Help;
//using ErpStudy.Application.Interfaces.UsesCases;
//using ErpStudy.Application.Interfaces.UsesCases.Categories;
//using ErpStudy.Application.Tests.Builders.Categories;
//using ErpStudy.Application.UseCases.Categories;
//using ErpStudy.Domain.Entities;
//using ErpStudy.WebAPI.Controllers;
//using FluentResults;
//using FluentValidation;
//using FluentValidation.Results;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Moq;
//using ValidationFailure = FluentValidation.Results.ValidationFailure;

//namespace ErpStudy.WebAPI.Tests.Unit.Controllers
//{
//    public class CategoryControllerTests
//    {
//        private readonly CategoryController _categoryController;
//        private readonly Mock<ICreateCategoryUseCase> _createCategoryUseCase;
//        private readonly Mock<IGetAllCategoriesUseCase> _gettAllCategoriesUseCase;
//        private readonly Mock<IGetCategoryByIdUseCase> _getCategoryByIdUseCase;
//        private readonly Mock<IUpdateCategoryUseCase> _updateCategoryUseCase;
//        private readonly Mock<IDeleteCategoryUseCase> _deleteCategoryUseCase;

//        public CategoryControllerTests(Mock<ILogger<CategoryController>> logger)
//        {
//            _categoryController = new CategoryController(logger.Object);
//        }

//        // CREATE

//        [Fact]
//        public async Task AddCategory_ValidCategory_Returns201Created()
//        {
//            // Arrange
//            var categoryDTO = CreateCategoryDTOBuilder.CreateFake();
//            _createCategoryUseCase.Setup(useCase => useCase.ExecuteAsync(It.IsAny<CreateCategoryDTO>()))
//                .ReturnsAsync(new Result<Category>());

//            // Act
//            CreatedResult? result = await _categoryController.AddCategory(categoryDTO) as CreatedResult;

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(201, result.StatusCode);
//            Assert.Equal("AddCategory", result.Location);
//            Assert.Equal(categoryDTO, result.Value);
//        }

//        [Fact]
//        public async Task AddCategory_InvalidCategory_Returns400BadRequestWithErrors()
//        {
//            // Arrange
//            var categoryDTO = new CreateCategoryDTOBuilder().WithName(null).Build();
//            _createCategoryUseCase.Setup(useCase => useCase.ExecuteAsync(It.IsAny<CreateCategoryDTO>()))
//                .ReturnsAsync(Result.Fail<Category>(new List<string> { "Err 1", "Err 2" }));

//            // Act
//            IActionResult result = await _categoryController.AddCategory(categoryDTO);

//            // Assert
//            Assert.NotNull(result);
//            Assert.IsType<BadRequestObjectResult>(result);

//            var badRequestResult = result as BadRequestObjectResult;
//            Assert.Equal(400, badRequestResult.StatusCode);
//            Assert.IsType<List<string>>(badRequestResult.Value);
//            var errors = badRequestResult.Value as List<string>;
//            Assert.Contains("Err 1", errors);
//            Assert.Contains("Err 2", errors);
//        }

//        [Fact]
//        public async Task AddCategory_ExceptionThrown_Returns500InternalServerError()
//        {
//            // Arrange
//            var categoryDTO = CreateCategoryDTOBuilder.CreateFake();
//            const string msgErr = Helper.MessageInfo.ErroTentarCadastrarRecurso;
//            _createCategoryUseCase.Setup(useCase => useCase.ExecuteAsync(It.IsAny<CreateCategoryDTO>()))
//                .ThrowsAsync(new Exception(msgErr));

//            // Act
//            ObjectResult? result = await _categoryController.AddCategory(categoryDTO) as ObjectResult;

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(500, result.StatusCode);
//            Assert.Equal(msgErr, result.Value);
//        }

//        // END CREATE

//        // READ

//        [Fact]
//        public async Task GetCategoryById_Returns_OK_When_Successful()
//        {
//            // Arrange
//            var getCategoryById = new GetCategoryByIdDTOBuilder().WithId(Guid.NewGuid()).Build();
//            var category = new Category { Id = getCategoryById.Id, Name = "Apagar - Teste" };
//            _getCategoryByIdUseCase.Setup(useCase => useCase.ExecuteAsync(getCategoryById))
//                .ReturnsAsync(new Result<Category>().WithValue(category));

//            // Act
//            var result = await _categoryController.GetCategoryById(getCategoryById);

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            Assert.Equal(category, okResult.Value);
//        }

//        [Fact]
//        public async Task GetCategoryById_Returns_NotFound_When_Failed()
//        {
//            // Arrange
//            var getCategoryById = new GetCategoryByIdDTOBuilder().WithId(Guid.NewGuid()).Build();
//            var error = "Category not found";
//            var failedResult = new Result<Category>().WithError(error);
//            _getCategoryByIdUseCase.Setup(x => x.ExecuteAsync(getCategoryById)).ReturnsAsync(failedResult);

//            // Act
//            var result = await _categoryController.GetCategoryById(getCategoryById);

//            // Assert
//            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
//            Assert.Equal(error, notFoundResult.Value);
//        }

//        [Fact]
//        public async Task GetCategoryById_Returns_InternalServerError_When_Exception()
//        {
//            // Arrange
//            var getCategoryById = new GetCategoryByIdDTOBuilder().WithId(Guid.NewGuid()).Build();
//            _getCategoryByIdUseCase.Setup(x => x.ExecuteAsync(getCategoryById))
//                .ThrowsAsync(new Exception("Some exception"));

//            // Act
//            var result = await _categoryController.GetCategoryById(getCategoryById);

//            // Assert
//            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
//            Assert.Equal(500, statusCodeResult.StatusCode);
//        }

//        [Fact]
//        public async Task GetAllCategories_Returns_OK_When_Successful()
//        {
//            // Arrange
//            var categories = new List<Category> { new Category { } };

//            _gettAllCategoriesUseCase.Setup(x => x.ExecuteAsync(null))
//                .ReturnsAsync(categories);
//            // Act
//            var result = await _categoryController.GetAllCategories();

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnedCategories = Assert.IsAssignableFrom<IEnumerable<Category>>(okResult.Value);
//            Assert.Equal(categories, returnedCategories);
//        }

//        [Fact]
//        public async Task GetAllCategories_Returns_InternalServerError_When_Exception()
//        {
//            // Arrange
//            _gettAllCategoriesUseCase.Setup(x => x.ExecuteAsync(null)).ThrowsAsync(new Exception("Some exception"));

//            // Act
//            var result = await _categoryController.GetAllCategories();

//            // Assert
//            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
//            Assert.Equal(500, statusCodeResult.StatusCode);
//        }

//        // END READ

//        // UPDATE

//        [Fact]
//        public async Task UpdateCategory_Returns_OK_When_Successful()
//        {
//            // Arrange
//            var category = UpdateCategoryDTOBuilder.CreateFake();
//            var validationResult = new ValidationResult();
//            _updateCategoryUseCase.Setup(x => x.ExecuteAsync(category)).ReturnsAsync(
//                new Result<Category> { });

//            // Act
//            var result = await _categoryController.UpdateCategory(category);

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            Assert.Equal(category, okResult.Value);
//        }

//        [Fact]
//        public async Task UpdateCategory_Returns_BadRequest_When_Validation_Fails()
//        {
//            // Arrange
//            var category = UpdateCategoryDTOBuilder.CreateFake();
//            var validationResult =
//                new ValidationResult(new List<ValidationFailure>
//                {
//                    new ValidationFailure("propertyName", "errorMessage")
//                });

//            // Mock validation failure
//            var validatorMock = new Mock<IValidator<UpdateCategoryDTO>>();
//            validatorMock.Setup(x => x.ValidateAsync(category, default)).ReturnsAsync(validationResult);

//            // Act
//            var result = await _categoryController.UpdateCategory(category);

//            // Assert
//            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//            Assert.Equal(validationResult.Errors, badRequestResult.Value);
//        }

//        [Fact]
//        public async Task UpdateCategory_Returns_NotFound_When_Failed()
//        {
//            // Arrange
//            var category = UpdateCategoryDTOBuilder.CreateFake();
//            var failedResult = new Result<Category>().WithError("Category not found");

//            _updateCategoryUseCase.Setup(x => x.ExecuteAsync(category)).ReturnsAsync(failedResult);

//            // Act
//            var result = await _categoryController.UpdateCategory(category);

//            // Assert
//            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
//            Assert.Equal(failedResult.Errors, notFoundResult.Value);
//        }

//        [Fact]
//        public async Task UpdateCategory_Returns_InternalServerError_When_Exception()
//        {
//            // Arrange
//            var category = UpdateCategoryDTOBuilder.CreateFake();
//            _updateCategoryUseCase.Setup(x => x.ExecuteAsync(category)).ThrowsAsync(new Exception("Some exception"));

//            // Act
//            var result = await _categoryController.UpdateCategory(category);

//            // Assert
//            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
//            Assert.Equal(500, statusCodeResult.StatusCode);
//        }

//        // END UPDATE

//        // DELETE
//        [Fact]
//        public async Task DeleteCategory_Returns_NoContent_When_Successful()
//        {
//            // Arrange
//            var id = DeleteCategoryDTOBuilder.CreateFake();
//            var validationResult = new ValidationResult();
//            var successfulResult = new Result<Category>();

//            _deleteCategoryUseCase.Setup(useCase => useCase.ExecuteAsync(id));

//            // Act
//            var result = await _categoryController.DeleteCategory(id);

//            // Assert
//            var noContentResult = Assert.IsType<NoContentResult>(result);
//            Assert.Equal(204, noContentResult.StatusCode);
//        }

//        [Fact]
//        public async Task DeleteCategory_Returns_BadRequest_When_Validation_Fails()
//        {
//            // Arrange
//            var id = DeleteCategoryDTOBuilder.CreateFake();
//            var validationResult =
//                new ValidationResult(new List<ValidationFailure>
//                {
//                    new ValidationFailure("propertyName", "errorMessage")
//                });

//            // Mock validation failure
//            var validatorMock = new Mock<IValidator<DeleteCategoryDTO>>();
//            validatorMock.Setup(x => x.ValidateAsync(id, default)).ReturnsAsync(validationResult);

//            // Act
//            var result = await _categoryController.DeleteCategory(id);

//            // Assert
//            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//            Assert.Equal(validationResult.Errors, badRequestResult.Value);
//        }

//        [Fact]
//        public async Task DeleteCategory_Returns_NotFound_When_Failed()
//        {
//            // Arrange
//            var id = DeleteCategoryDTOBuilder.CreateFake();
//            var failedResult = new Result<Category>().WithError("Category not found");

//            _deleteCategoryUseCase.Setup(x => x.ExecuteAsync(id));

//            // Act
//            var result = await _categoryController.DeleteCategory(id);

//            // Assert
//            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
//            Assert.Equal(failedResult.Errors, notFoundResult.Value);
//        }

//        [Fact]
//        public async Task DeleteCategory_Returns_InternalServerError_When_Exception()
//        {
//            // Arrange
//            var id = DeleteCategoryDTOBuilder.CreateFake();
//            _deleteCategoryUseCase.Setup(x => x.ExecuteAsync(id)).ThrowsAsync(new Exception("Some exception"));

//            // Act
//            var result = await _categoryController.DeleteCategory(id);

//            // Assert
//            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
//            Assert.Equal(500, statusCodeResult.StatusCode);
//        }

//        // END DELETE
//    }
//}