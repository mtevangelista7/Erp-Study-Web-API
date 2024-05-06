using ErpStudy.Application.DTOs.Products;
using ErpStudy.Application.Help;
using ErpStudy.Application.Interfaces.UsesCases.Categories;
using ErpStudy.Application.Interfaces.UsesCases.Products;
using ErpStudy.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErpStudy.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ILogger<ProductController> logger) : ControllerBase
    {
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(CreateProductDTO request,
            ICreateProductUseCase createProductUseCase)
        {
            try
            {
                var result = await createProductUseCase.ExecuteAsync(request);

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                return Created(nameof(AddProduct), result.Value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, Helper.MessageInfo.ErroTentarCadastrarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetProductById{getProductByIdUseCase}")]
        public async Task<IActionResult> GetProductById(GetProductByIdDTO request,
            IGetProductByIdUseCase getProductByIdUseCase)
        {
            try
            {
                var result = await getProductByIdUseCase.ExecuteAsync(request);

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                if (result.Value is null)
                {
                    return NotFound();
                }

                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, Helper.MessageInfo.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts(IGetAllProductsUseCase getAllProductsUseCase)
        {
            try
            {
                var result = await getAllProductsUseCase.ExecuteAsync();

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                if (result.Value is null || result.Value.Count == 0)
                {
                    return NotFound();
                }

                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, Helper.MessageInfo.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO request,
            IUpdateProductUseCase updateProductUseCase)
        {
            try
            {
                var result = await updateProductUseCase.ExecuteAsync(request);

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                if (result.Value is null)
                {
                    return NotFound();
                }

                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, Helper.MessageInfo.ErroTentarAtualizarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(DeleteProductDTO request,
            IDeleteProductUseCase deleteProductUseCase)
        {
            try
            {
                var result = await deleteProductUseCase.ExecuteAsync(request);

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, Helper.MessageInfo.ErroTentarDeletarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}