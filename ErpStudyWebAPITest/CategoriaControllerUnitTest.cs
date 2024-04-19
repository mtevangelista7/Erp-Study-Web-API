using Moq;
using ErpStudyWebAPI.Controllers;
using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Services.CategoriaServices;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Erp_Study_Web_API_Test
{
    public class CategoriaControllerUnitTest
    {
        private readonly Mock<ICategoriaService> _categoriaServiceMock;
        private readonly Mock<ILogger<CategoriaController>> _loggerMock;
        private readonly Mock<IValidator<Categoria>> _validator;
    
        public CategoriaControllerUnitTest()
        {
            _categoriaServiceMock = new Mock<ICategoriaService>();
            _loggerMock = new Mock<ILogger<CategoriaController>>();
            _validator = new Mock<IValidator<Categoria>>();
        }
    
        [Fact]
        public async Task RetornaCategoria_DeveRetornarOk_QuandoGuidIDForValido()
        {
            // Arrange
            Guid guidID = Guid.NewGuid();
            Categoria categoria = new();
            _categoriaServiceMock.Setup(x => x.RetornaCategoria(guidID)).ReturnsAsync(categoria);
            CategoriaController controller = new(_loggerMock.Object, _categoriaServiceMock.Object, _validator.Object);

            // Act
            IActionResult? result = await controller.RetornaCategoria(guidID);

            // Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(categoria, okResult.Value);
        }

        [Fact]
        public async Task AdicionarCategoria_Returns_Created()
        {
            // Arrange
            Mock<ICategoriaService> categoriaServiceMock = new();
            Mock<ILogger<CategoriaController>> loggerMock = new();
            Mock<IValidator<Categoria>> validator = new();
            CategoriaController controller = new(loggerMock.Object, categoriaServiceMock.Object, validator.Object);

            Categoria categoria = new() {Nome = "Apagar"};

            // Act
            StatusCodeResult? result = await controller.AdicionarCategoria(categoria) as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
            categoriaServiceMock.Verify(service => service.AdicionarCategoria(categoria), Times.Once);
        }
    
        [Fact]
        public async Task AdicionarCategoria_Returns_BadRequest_When_Categoria_Is_Null()
        {
            // Arrange
            Mock<ICategoriaService> categoriaServiceMock = new();
            Mock<ILogger<CategoriaController>> loggerMock = new();
            Mock<IValidator<Categoria>> validator = new();
            CategoriaController controller = new(loggerMock.Object, categoriaServiceMock.Object, validator.Object);

            // Act
            StatusCodeResult? result = await controller.AdicionarCategoria(null) as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            categoriaServiceMock.Verify(service => service.AdicionarCategoria(It.IsAny<Categoria>()), Times.Never);
        }
    }
}