using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Services;
using ErpStudyWebAPI.Services.ProdutoServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoService _produtoService;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }

        /// <summary>
        /// Retorna uma lista com todos os produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> RetornaProdutos()
        {
            try
            {
                return Ok(await _produtoService.RetornarProdutos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar categoria");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Adicina um novo produto
        /// </summary>
        /// <remarks>teste</remarks>
        /// <response code="201">Produto criado com sucesso!</response>
        /// <response code="500">Não foi possível criar o produto no momento, tente novamente mais tarde!</response>
        /// <response code="400">O objeto produto não foi enviado corretamente, verifique e tente novamente!</response>
        [HttpPost]
        public async Task<IActionResult> AdicionarProduto(Produto produto)
        {
            try
            {
                if (produto is null)
                {
                    return BadRequest();
                }

                await _produtoService.AdicionarProduto(produto);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar categoria");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}