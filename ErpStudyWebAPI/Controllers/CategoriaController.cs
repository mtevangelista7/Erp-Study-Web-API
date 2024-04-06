using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ILogger<CategoriaController> logger)
        {
            _logger = logger;
        }

        [HttpPost("AdicionarCategoria")]
        public async Task<IActionResult> AdicionarCategoria([FromBody] Categoria categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                CategoriaService categoriaService = new CategoriaService();

                await categoriaService.AdicionarCategoria(categoria);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar categoria");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("RetornaCategoria")]
        public async Task<IActionResult> RetornaCategoria([FromBody] Guid guidID)
        {
            try
            {
                CategoriaService categoriaService = new CategoriaService();

                return Ok(await categoriaService.RetornaCategoria(guidID));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter categoria");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("RetornaCategorias")]
        public async Task<IActionResult> RetornaCategorias()
        {
            try
            {
                CategoriaService categoriaService = new CategoriaService();

                return Ok(await categoriaService.RetornaCategorias());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter as categorias");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("AtualizaCategoria")]
        public async Task<IActionResult> AtualizaCategoria([FromBody] Categoria categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                CategoriaService categoriaService = new CategoriaService();

                await categoriaService.AtualizarCategoria(categoria);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar categoria");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeletaCategoria")]
        public async Task<IActionResult> DeletaCategoria([FromBody] Guid guidID)
        {
            try
            {
                if (guidID == Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                CategoriaService categoriaService = new CategoriaService();

                await categoriaService.DeletarCategoria(guidID);

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
