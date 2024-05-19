using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Help;
using ErpStudy.Application.Interfaces.UsesCases.Categories;
using ErpStudy.Application.UseCases.Categories;
using ErpStudy.Application.Validator.CategoryDTOValidator;
using ErpStudy.Domain.Entities;
using FluentResults;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErpStudy.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="createCategoryUseCase"></param>
    /// <param name="deleteCategoryUseCase"></param>
    /// <param name="getAllCategoriesUseCase"></param>
    /// <param name="getCategoryByIdUseCase"></param>
    /// <param name="updateCategoryUseCase"></param>
    /// <param name="logger"></param>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDTO category, ICreateCategoryUseCase createCategoryUseCase)
        {
            try
            {
                Result<Category> result = await createCategoryUseCase.ExecuteAsync(category);

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                return Created(nameof(AddCategory), result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Helper.MessageInfo.ErroTentarCadastrarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("GetCategoryById{id}")]
        public async Task<IActionResult> GetCategoryById(GetCategoryByIdDTO id, IGetCategoryByIdUseCase getCategoryByIdUseCase)
        {
            try
            {
                Result<Category> result = await getCategoryByIdUseCase.ExecuteAsync(id);

                if (result.IsFailed)
                {
                    return NotFound(result.Errors);
                }

                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Helper.MessageInfo.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult> GetAllCategories([FromServices] IGetAllCategoriesUseCase getAllCategoriesUseCase)
        {
            try
            {
                return Ok(await getAllCategoriesUseCase.ExecuteAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Helper.MessageInfo.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDTO category, IUpdateCategoryUseCase updateCategoryUseCase)
        {
            try
            {
                ValidationResult validationResult = await new UpdateCategoryDTOValidator().ValidateAsync(category);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                Result<Category> result = await updateCategoryUseCase.ExecuteAsync(category);

                if (result.IsSuccess)
                {
                    return Ok(result.Value);
                }

                return NotFound(result.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Helper.MessageInfo.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteCategory{id}")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryDTO id, IDeleteCategoryUseCase deleteCategoryUseCase)
        {
            try
            {
                ValidationResult validationResult = await new DeleteCategoryDTOValidator().ValidateAsync(id);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                Result<Category> result = await deleteCategoryUseCase.ExecuteAsync(id);

                if (result.IsSuccess)
                {
                    return NoContent();
                }

                return NotFound(result.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Helper.MessageInfo.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}