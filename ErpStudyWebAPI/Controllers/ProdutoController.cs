using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Services;
using ErpStudyWebAPI.Services.ProdutoServices;
using ErpStudyWebAPI.Utilities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        /// Retorna todos os produtos existentes no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /retornaprodutos
        ///
        /// </remarks>
        /// <returns>Uma lista de produtos.</returns>
        /// <response code="200">Lista de produtos retornada com sucesso.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Produto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RetornaProdutos()
        {
            try
            {
                // retorna uma lista de produtos
                return Ok(await _produtoService.RetornarProdutos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Util.MensagensStrings.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um novo produto ao sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /produtos/adicionarproduto
        ///     {
        ///         "Nome": "Novo Produto",
        ///         "CodigoSKU": " ",
        ///         "PrecoVenda": 10.99,
        ///         "Unidade" : 0 (0: UNIDADE, 1: QUILOGRAMA, 2: LITRO, 3: METRO)
        ///         "Condicao" : 0 (0: NOVO, 1: USADO)
        ///         "Categoria": " "
        ///     }
        ///
        /// </remarks>
        /// <param name="produto">Os dados do novo produto a serem adicionados.</param>
        /// <returns>O produto adicionado.</returns>
        /// <response code="201">Produto adicionado com sucesso.</response>
        /// <response code="400">Requisição inválida. Verifique os detalhes da solicitação.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AdicionarProduto")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarProduto([FromBody] Produto produto)
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
                Produto produtoCadastrado = await _produtoService.AdicionarProduto(produto);

                // Caso não consiga adicionar o produto
                if (produtoCadastrado is null)
                {
                    // retorna bad request com mensagem
                    return BadRequest(Util.MensagensStrings.ErroTentarCadastrarRecurso);
                }

                // Retorna 201 de item criado com sucesso
                return Created(nameof(AdicionarProduto), produtoCadastrado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Util.MensagensStrings.ErroTentarCadastrarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um produto existente no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /api/produtos/AtualizaProduto
        ///     {
        ///         "Nome": "Novo Produto",
        ///         "CodigoSKU": " ",
        ///         "PrecoVenda": 10.99,
        ///         "Unidade" : 0 (0: UNIDADE, 1: QUILOGRAMA, 2: LITRO, 3: METRO)
        ///         "Condicao" : 0 (0: NOVO, 1: USADO)
        ///         "Categoria": " "
        ///     }
        ///
        /// </remarks>
        /// <param name="produtoSelecionado">Os novos dados do produto a serem atualizados.</param>
        /// <returns>O produto atualizado.</returns>
        /// <response code="200">Produto atualizado com sucesso.</response>
        /// <response code="400">Requisição inválida. Verifique os detalhes da solicitação.</response>
        /// <response code="404">Recurso não encontrado. O produto especificado não foi encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("AtualizaProduto")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

                // Realiza o update do produto na base
                if (await _produtoService.AtualizarProduto(produtoSelecionado))
                {
                    // Caso tenha conseguido, atualizar, retorna 200 com o produto
                    return Ok(produtoSelecionado);
                }

                // Caso não tenha conseguido atualizar, retorna 404 com a mensagem
                return NotFound(Util.MensagensStrings.RecursoNaoEncontrado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Util.MensagensStrings.ErroTentarAtualizarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Deleta um produto existente no sistema com base no GUID fornecido.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /api/produtos/deletarproduto?guidProduto=00000000-0000-0000-0000-000000000000
        ///
        /// </remarks>
        /// <param name="guidProduto">O GUID do produto a ser deletado.</param>
        /// <returns>Nenhum conteúdo.</returns>
        /// <response code="204">Produto deletado com sucesso.</response>
        /// <response code="400">Requisição inválida. O GUID do produto não foi fornecido corretamente.</response>
        /// <response code="404">Recurso não encontrado. O produto especificado não foi encontrado.</response>
        [HttpDelete("DeletarProduto{guidProduto}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletarProduto(Guid guidProduto)
        {
            // Caso não seja válido
            if (guidProduto == Guid.Empty)
            {
                return BadRequest(Util.MensagensStrings.RecursoFornecidoForaEsperado);
            }

            // chama o serviço para tentar deletar o produto service
            if (await _produtoService.DeletarProduto(guidProduto))
            {
                // Caso tenha conseguido excluir, retorna 204
                return NoContent();
            }

            // caso não consiga realizar a exclusão, retorna not found com mensagem de erro
            return NotFound(Util.MensagensStrings.RecursoNaoEncontrado);
        }
    }
}