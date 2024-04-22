using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Services;
using ErpStudyWebAPI.Services.ProdutoServices;
using FluentValidation;
using FluentValidation.Results;
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
        private readonly IValidator<Produto> _validator;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService,
            IValidator<Produto> validator)
        {
            _logger = logger;
            _produtoService = produtoService;
            _validator = validator;
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
                // Realiza a validação do resultado
                ValidationResult validationResult = await _validator.ValidateAsync(produto);

                // Caso a validação não passe
                if (!validationResult.IsValid)
                {
                    // retorna um badrequest com o objeto de erro
                    return BadRequest(validationResult.Errors);
                }

                // Adiciona o produto
                await _produtoService.AdicionarProduto(produto);

                // Retorna 201 de item criado com sucesso
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar produto");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um produto existente
        /// </summary>
        /// <param name="produtoSelecionado"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> AtualizaProduto(Produto produtoSelecionado)
        {
            try
            {
                // Realiza a validação do objeto produto
                ValidationResult validatorResult = await _validator.ValidateAsync(produtoSelecionado);

                // Caso não seja válido retorna um badrequest com erros
                if (!validatorResult.IsValid)
                {
                    return BadRequest(validatorResult.Errors);
                }

                // Realiza a atualização do item selecionado
                produtoSelecionado = await _produtoService.AtualizarProduto(produtoSelecionado);

                // retorna o 201 com o item atualizado
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar produto");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Deleta um produto selecionado
        /// </summary>
        /// <param name="produtoSelecionado"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeletarProduto(Produto produtoSelecionado)
        {
            // Realiza a validação do produto
            ValidationResult validatorResult = await _validator.ValidateAsync(produtoSelecionado);

            // Caso não seja válido
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            // Retorna 201 com o produto que foi deletado
            return CreatedAtAction(nameof(DeletarProduto), await _produtoService.DeletarProduto(produtoSelecionado));
        }
    }
}