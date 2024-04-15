using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Services;
using ErpStudyWebAPI.Services.CategoriaServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ClaimsPrincipal ClaimsPrincipalUsuario { get; }
        
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaService _categoriaService;
        
        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService)
        {
            _logger = logger;
            _categoriaService  = categoriaService;
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
                if (categoria == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                await _categoriaService.AdicionarCategoria(categoria);

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
        public async Task<IActionResult> RetornaCategoria([FromBody] Guid guidID)
        {
            try
            {
                //Guid usuarioId = Guid.Parse(ClaimsPrincipalUsuario.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                
                if (guidID == Guid.Empty)
                    return StatusCode(StatusCodes.Status400BadRequest);

                return Ok(await _categoriaService.RetornaCategoria(guidID));
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
        public async Task<IActionResult> AtualizaCategoria([FromBody] Categoria categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                await _categoriaService.AtualizarCategoria(categoria);

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
        public async Task<IActionResult> DeletaCategoria([FromBody] Guid guidID)
        {
            try
            {
                if (guidID == Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                await _categoriaService.DeletarCategoria(guidID);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar categoria");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
