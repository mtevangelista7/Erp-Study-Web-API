using Moq;
using ErpStudyWebAPI.Controllers;
using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Services.CategoriaServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Erp_Study_Web_API_Test;

public class CategoriaControllerUnitTest
{
    private readonly Mock<ICategoriaService> _categoriaServiceMock;
    private readonly Mock<ILogger<CategoriaController>> _loggerMock;
    
    public CategoriaControllerUnitTest()
    {
        _categoriaServiceMock = new Mock<ICategoriaService>();
        _loggerMock = new Mock<ILogger<CategoriaController>>();
    }
    
    [Fact]
    public async Task RetornaCategoria_DeveRetornarOk_QuandoGuidIDForValido()
    {
        // Arrange
        Guid guidID = Guid.NewGuid();
        Categoria categoria = new Categoria(); // Supondo que Categoria seja o tipo retornado pelo _categoriaService
        _categoriaServiceMock.Setup(x => x.RetornaCategoria(guidID)).ReturnsAsync(categoria);
        CategoriaController controller = new CategoriaController(_loggerMock.Object, _categoriaServiceMock.Object);

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
        var categoriaServiceMock = new Mock<ICategoriaService>();
        var loggerMock = new Mock<ILogger<CategoriaController>>();
        var controller = new CategoriaController(loggerMock.Object, categoriaServiceMock.Object);

        var categoria = new Categoria {Nome = "Apagar"};

        // Act
        var result = await controller.AdicionarCategoria(categoria) as StatusCodeResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
        categoriaServiceMock.Verify(service => service.AdicionarCategoria(categoria), Times.Once);
    }
    
    [Fact]
    public async Task AdicionarCategoria_Returns_BadRequest_When_Categoria_Is_Null()
    {
        // Arrange
        var categoriaServiceMock = new Mock<ICategoriaService>();
        var loggerMock = new Mock<ILogger<CategoriaController>>();
        var controller = new CategoriaController(loggerMock.Object, categoriaServiceMock.Object);

        // Act
        var result = await controller.AdicionarCategoria(null) as StatusCodeResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        categoriaServiceMock.Verify(service => service.AdicionarCategoria(It.IsAny<Categoria>()), Times.Never);
    }
}