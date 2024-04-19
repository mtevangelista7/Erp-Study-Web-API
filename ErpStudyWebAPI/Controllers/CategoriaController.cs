using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Services;
using ErpStudyWebAPI.Services.CategoriaServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaService _categoriaService;
        private readonly IValidator<Categoria> _validator;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService,
            IValidator<Categoria> validator)
        {
            _logger = logger;
            _categoriaService = categoriaService;
            _validator = validator;
        }

        /// <summary>
        /// Adicina um nova categoria
        /// </summary>
        /// <remarks>teste</remarks>
        /// <response code="201">Categoria criada com sucesso!</response>
        /// <response code="500">Não foi possível criar a categoria no momento, tente novamente mais tarde!</response>
        /// <response code="400">O objeto categoria não foi enviado corretamente, verifique e tente novamente!</response>
        [HttpPost("AdicionarCategoria")]
        [ProducesResponseType(typeof(Categoria), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AdicionarCategoria([FromBody] Categoria categoria)
        {
            try
            {
                // Valida o objeto do body
                ValidationResult validation = await _validator.ValidateAsync(categoria);

                // Caso o objeto seja invalido, retorna um badrequest com as informações de erro
                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors);
                }

                // Caso o objeto esteja valido, chama o serviço e adiciona a nova categoria
                await _categoriaService.AdicionarCategoria(categoria);

                // Retorna 201 de sucesso
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar categoria");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma categoria pelo ID
        /// </summary>
        /// <remarks>teste</remarks>
        /// <response code="200">Categoria retornada com sucesso</response>
        /// <response code="500">Não foi possível retonar a categoria no momento, tente novamente mais tarde!</response>
        /// <response code="400">O objeto id não foi enviado corretamente, verifique e tente novamente!</response>
        [HttpPost("RetornaCategoria")]
        public async Task<IActionResult> RetornaCategoria([FromBody] Guid categoriaSelecionadaguidID)
        {
            try
            {
                // Caso o guid recebido não seja valido, retorna um badrequest
                if (categoriaSelecionadaguidID == Guid.Empty)
                    return StatusCode(StatusCodes.Status400BadRequest);

                // realiza a busca da categoria pelo service e retorna a mesmo com o 200
                return Ok(await _categoriaService.RetornaCategoria(categoriaSelecionadaguidID));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter categoria");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista com todas as categorias
        /// </summary>
        /// <remarks>teste</remarks>
        /// <response code="200">Categorias retornadas com sucesso</response>
        /// <response code="500">Não foi possível retonar a categoria no momento, tente novamente mais tarde!</response>
        [HttpGet("RetornaCategorias")]
        public async Task<IActionResult> RetornaCategorias()
        {
            try
            {
                // retorna todas as categorias com 200
                return Ok(await _categoriaService.RetornaCategorias());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter as categorias");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma categoria pelo ID
        /// </summary>
        /// <remarks>teste</remarks>
        /// <response code="200">Categoria retornada atualizada com sucesso!</response>
        /// <response code="500">Não foi possível atualizar a categoria no momento, tente novamente mais tarde!</response>
        [HttpPut("AtualizaCategoria")]
        public async Task<IActionResult> AtualizaCategoria([FromBody] Categoria categoriaSelecionada)
        {
            try
            {
                // Realiza a validação do objeto recebido
                ValidationResult validationResult = await _validator.ValidateAsync(categoriaSelecionada);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                // Atualiza a categoria e retorna 200
                // TODO Aqui acho melhor passar algo para a response, para saber se atualizou ou não localizou
                await _categoriaService.AtualizarCategoria(categoriaSelecionada);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar categoria");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma categoria pelo ID
        /// </summary>
        /// <remarks>teste</remarks>
        /// <response code="200">Categoria retornada atualizada com sucesso!</response>
        /// <response code="500">Não foi possível atualizar a categoria no momento, tente novamente mais tarde!</response>
        [HttpDelete("DeletaCategoria")]
        public async Task<IActionResult> DeletaCategoria([FromBody] Guid categoriaSelecionadaguidID)
        {
            try
            {
                // Caso o Guid esteja inválido, retorna um badrequest
                if (categoriaSelecionadaguidID == Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                // retorna um 200 com o guid do objeto que foi deletado
                return Ok(await _categoriaService.DeletarCategoria(categoriaSelecionadaguidID));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar categoria");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}