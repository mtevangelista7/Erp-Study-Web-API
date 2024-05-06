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

        /// <summary>
        /// Adiciona uma nova categoria ao sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/category/AddCategory
        ///     {
        ///         "Name": "Nova Categoria"
        ///     }
        ///
        /// </remarks>
        /// <param name="category">Os dados da nova categoria a serem adicionados.</param>
        /// <returns>O objeto da nova categoria adicionada.</returns>
        /// <response code="201">Categoria adicionada com sucesso.</response>
        /// <response code="400">Requisição inválida. Verifique os detalhes da solicitação.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AddCategory")]
        [ProducesResponseType(typeof(CreateCategoryDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Retorna uma categoria existente no sistema com base no GUID fornecido.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /GetCategoryById{guidCategoria}
        /// 
        /// </remarks>
        /// <param name="id">O GUID da categoria a ser retornada.</param>
        /// <returns>A categoria encontrada.</returns>
        /// <response code="200">Categoria encontrada com sucesso.</response>
        /// <response code="400">Requisição inválida. O GUID da categoria não foi fornecido corretamente.</response>
        /// <response code="404">Recurso não encontrado. A categoria especificada não foi encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("GetCategoryById{id}")]
        [ProducesResponseType(typeof(GetCategoryByIdDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Retorna todas as categorias existentes no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /GetAllCategories
        ///
        /// </remarks>
        /// <returns>Uma lista de todas as categorias.</returns>
        /// <response code="200">Lista de categorias retornada com sucesso.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("GetAllCategories")]
        [ProducesResponseType(typeof(IEnumerable<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCategories(IGetAllCategoriesUseCase getAllCategoriesUseCase)
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

        /// <summary>
        /// Atualiza uma categoria existente no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /updateCategory
        ///     {
        ///         "CategoriaID": "00000000-0000-0000-0000-000000000000",
        ///         "Nome": "Categoria Atualizada",
        ///         "Descricao": "Descrição da categoria atualizada."
        ///     }
        ///
        /// </remarks>
        /// <param name="category">Os novos dados da categoria a serem atualizados.</param>
        /// <returns>A categoria atualizada.</returns>
        /// <response code="200">Categoria atualizada com sucesso.</response>
        /// <response code="400">Requisição inválida. Verifique os detalhes da solicitação.</response>
        /// <response code="404">Recurso não encontrado. A categoria especificada não foi encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("UpdateCategory")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Deleta uma categoria existente no sistema com base no GUID fornecido.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /DeletaCategoria?guidUsuario=00000000-0000-0000-0000-000000000000
        ///
        /// </remarks>
        /// <param name="id">O GUID da categoria a ser deletada.</param>
        /// <returns>Nenhum conteúdo.</returns>
        /// <response code="204">Categoria deletada com sucesso.</response>
        /// <response code="400">Requisição inválida. O GUID da categoria não foi fornecido corretamente.</response>
        /// <response code="404">Recurso não encontrado. A categoria especificada não foi encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("DeleteCategory{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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