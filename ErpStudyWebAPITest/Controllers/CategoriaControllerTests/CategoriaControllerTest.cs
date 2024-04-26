using ErpStudyWebAPI.Controllers;
using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Services.CategoriaServices;
using ErpStudyWebAPI.Utilities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Erp_Study_Web_API_Test.Controllers.CategoriaControllerTests
{
    public class CategoriaControllerTest
    {
        private readonly Mock<ICategoriaService> _categoriaServiceMock;
        private readonly Mock<ILogger<CategoriaController>> _loggerMock;
        private readonly Mock<IValidator<Categoria>> _validator;

        public CategoriaControllerTest()
        {
            _categoriaServiceMock = new Mock<ICategoriaService>();
            _loggerMock = new Mock<ILogger<CategoriaController>>();
            _validator = new Mock<IValidator<Categoria>>();
        }

        // Create

        [Fact]
        public async Task AdicionarCategoria_ValidCategoria_Returns201Created()
        {
            // Arrange
            Categoria categoria = new() { Nome = $"Apagar - {DateTime.Now}" };
            _categoriaServiceMock.Setup(service => service.AdicionarCategoria(categoria));
            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            CreatedResult? result = await controller.AdicionarCategoria(categoria) as CreatedResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal("AdicionarCategoria", result.Location);
            Assert.Equal(categoria, result.Value);
        }

        [Fact]
        public async Task AdicionarCategoria_InvalidCategoria_Returns400BadRequestWithErrors()
        {
            // Arrange
            Categoria categoria = new(); // tem que ser inválida
            _categoriaServiceMock.Setup(service => service.AdicionarCategoria(categoria));
            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            BadRequestObjectResult? result = await controller.AdicionarCategoria(categoria) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.IsType<List<ValidationFailure>>(result.Value);
        }

        [Fact]
        public async Task AdicionarCategoria_ExceptionThrown_Returns500InternalServerError()
        {
            // Arrange
            Categoria categoria = new() { Nome = $"Apagar - {DateTime.Now}" };
            const string mensagemErro = Util.MensagensStrings.ErroTentarCadastrarRecurso;
            _categoriaServiceMock.Setup(s => s.AdicionarCategoria(categoria))
                .ThrowsAsync(new Exception(mensagemErro));
            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object,
                _validator.Object);

            // Act
            ObjectResult? result = await controller.AdicionarCategoria(categoria) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal(mensagemErro, result.Value);
        }

        // End Create

        // Read

        [Fact]
        public async Task RetornaCategoria_ValidGuid_Returns200OK()
        {
            // Arrange
            Guid guidValido = Guid.NewGuid();

            Categoria categoriaEsperada = new() { Nome = "Não Apagar Teste", CategoriaID = guidValido };

            _categoriaServiceMock.Setup(service => service.RetornaCategoria(guidValido))
                .ReturnsAsync(categoriaEsperada);

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.RetornaCategoria(guidValido);

            // Assert
            OkObjectResult resultadoOK = Assert.IsType<OkObjectResult>(result);
            Categoria categoriaRetornada = Assert.IsType<Categoria>(resultadoOK.Value);
            Assert.Equal(categoriaEsperada, categoriaRetornada);
        }

        [Fact]
        public async Task RetornaCategoria_NotFound_Returns404NotFound()
        {
            // Arrange
            Guid guidNaoCadastradoBase = Guid.NewGuid();
            _categoriaServiceMock.Setup(service => service.RetornaCategoria(guidNaoCadastradoBase))
                .ReturnsAsync((Categoria)null!);

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.RetornaCategoria(guidNaoCadastradoBase);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task RetornaCategoria_InternalServerError_Returns500InternalServerError()
        {
            // Arrange
            Guid guidValido = Guid.NewGuid();
            _categoriaServiceMock.Setup(service => service.RetornaCategoria(guidValido))
                .ThrowsAsync(new Exception(Util.MensagensStrings.ErroTentarObterRecurso));

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.RetornaCategoria(guidValido);

            // Assert
            StatusCodeResult resultadoStatusCode = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, resultadoStatusCode.StatusCode);
        }


        [Fact]
        public async Task RetornaCategorias_Returns200OK()
        {
            // Arrange
            List<Categoria> expectedCategorias =
            [
                new Categoria { },

                new Categoria { }
            ];

            _categoriaServiceMock.Setup(service => service.RetornaCategorias())
                .ReturnsAsync(expectedCategorias);

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.RetornaCategorias();

            // Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            IEnumerable<Categoria> returnedCategorias = Assert.IsAssignableFrom<IEnumerable<Categoria>>(okResult.Value);
            Assert.Equal(expectedCategorias, returnedCategorias);
        }

        [Fact]
        public async Task RetornaCategorias_InternalServerError_Returns500InternalServerError()
        {
            // Arrange
            _categoriaServiceMock.Setup(service => service.RetornaCategorias())
                .ThrowsAsync(new Exception(Util.MensagensStrings.ErroTentarObterRecurso));

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.RetornaCategorias();

            // Assert
            StatusCodeResult statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        // End Read

        // Update

        [Fact]
        public async Task AtualizaCategoria_ValidInput_Returns200OK()
        {
            // Arrange
            Categoria categoriaValida = new() { };

            _validator.Setup(validator => validator.ValidateAsync(categoriaValida, default))
                .ReturnsAsync(new ValidationResult());

            _categoriaServiceMock.Setup(service => service.AtualizarCategoria(categoriaValida))
                .ReturnsAsync(true);

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.AtualizaCategoria(categoriaValida);

            // Assert
            OkObjectResult resultadoOK = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(categoriaValida, resultadoOK.Value);
        }

        [Fact]
        public async Task AtualizaCategoria_InvalidInput_Returns400BadRequest()
        {
            // Arrange
            Categoria invalidCategoria = new() { };

            _validator.Setup(validator => validator.ValidateAsync(invalidCategoria, default))
                .ReturnsAsync(new ValidationResult(new[] { new ValidationFailure("", "") }));

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.AtualizaCategoria(invalidCategoria);

            // Assert
            BadRequestObjectResult badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsAssignableFrom<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task AtualizaCategoria_ServiceReturnsFalse_Returns404NotFound()
        {
            // Arrange
            Categoria categoriaValida = new() { };

            _validator.Setup(validator => validator.ValidateAsync(categoriaValida, default))
                .ReturnsAsync(new ValidationResult());

            _categoriaServiceMock.Setup(service => service.AtualizarCategoria(categoriaValida))
                .ReturnsAsync(false);

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.AtualizaCategoria(categoriaValida);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task AtualizaCategoria_InternalServerError_Returns500InternalServerError()
        {
            // Arrange
            Categoria categoriaValida = new() { };

            _validator.Setup(validator => validator.ValidateAsync(categoriaValida, default))
                .ReturnsAsync(new ValidationResult());

            _categoriaServiceMock.Setup(service => service.AtualizarCategoria(categoriaValida))
                .ThrowsAsync(new Exception(Util.MensagensStrings.ErroTentarAtualizarRecurso));

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.AtualizaCategoria(categoriaValida);

            // Assert
            StatusCodeResult resultadoStatusCode = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, resultadoStatusCode.StatusCode);
        }

        // End Update


        // Delete

        [Fact]
        public async Task DeletaCategoria_ValidGuid_Returns204NoContent()
        {
            // Arrange
            Guid guidValido = Guid.NewGuid();
            _categoriaServiceMock.Setup(service => service.DeletarCategoria(guidValido))
                .ReturnsAsync(true);

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.DeletaCategoria(guidValido);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeletaCategoria_EmptyGuid_Returns400BadRequest()
        {
            // Arrange
            Guid guidVazio = Guid.Empty;
            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.DeletaCategoria(guidVazio);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DeletaCategoria_NotFound_Returns404NotFound()
        {
            // Arrange
            Guid guidNaoExistente = Guid.NewGuid();
            _categoriaServiceMock.Setup(service => service.DeletarCategoria(guidNaoExistente))
                .ReturnsAsync(false);

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.DeletaCategoria(guidNaoExistente);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task DeletaCategoria_InternalServerError_Returns500InternalServerError()
        {
            // Arrange
            Guid guidValido = Guid.NewGuid();
            _categoriaServiceMock.Setup(service => service.DeletarCategoria(guidValido))
                .ThrowsAsync(new Exception(Util.MensagensStrings.ErroTentarDeletarRecurso));

            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.DeletaCategoria(guidValido);

            // Assert
            StatusCodeResult statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        // End Delete 
    }
}