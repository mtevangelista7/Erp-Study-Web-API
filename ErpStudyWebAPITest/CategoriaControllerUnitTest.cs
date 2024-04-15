using Moq;
using ErpStudyWebAPI.Controllers;
using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Services.CategoriaServices;
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
}