using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Services;
using ErpStudyWebAPI.Services.CategoriaServices;
using ErpStudyWebAPI.Utilities;
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
        /// Adiciona uma nova categoria ao sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/categorias/AdicionarCategoria
        ///     {
        ///         "Nome": "Nova Categoria",
        ///         "Descricao": "Descrição da nova categoria."
        ///     }
        ///
        /// </remarks>
        /// <param name="categoria">Os dados da nova categoria a serem adicionados.</param>
        /// <returns>O objeto da nova categoria adicionada.</returns>
        /// <response code="201">Categoria adicionada com sucesso.</response>
        /// <response code="400">Requisição inválida. Verifique os detalhes da solicitação.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("AdicionarCategoria")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                return Created(nameof(AdicionarCategoria), categoria);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Util.MensagensStrings.ErroTentarCadastrarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma categoria existente no sistema com base no GUID fornecido.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /RetornaCategoria{guidCategoria}
        ///
        /// </remarks>
        /// <param name="guidCategoria">O GUID da categoria a ser retornada.</param>
        /// <returns>A categoria encontrada.</returns>
        /// <response code="200">Categoria encontrada com sucesso.</response>
        /// <response code="400">Requisição inválida. O GUID da categoria não foi fornecido corretamente.</response>
        /// <response code="404">Recurso não encontrado. A categoria especificada não foi encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("RetornaCategoria{guidCategoria}")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RetornaCategoria(Guid guidCategoria)
        {
            try
            {
                // Caso o guid recebido não seja valido, retorna um badrequest
                if (guidCategoria == Guid.Empty)
                    return BadRequest(Util.MensagensStrings.RecursoFornecidoForaEsperado);

                // Realiza a busca da categoria
                Categoria categoria = await _categoriaService.RetornaCategoria(guidCategoria);

                // Caso não tenha localizado a mesma
                if (categoria is null)
                {
                    // retorna o not found com a mensagem
                    return NotFound(Util.MensagensStrings.RecursoNaoEncontrado);
                }

                // Caso tenha localizado, retorna 200 com o objeto criado
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Util.MensagensStrings.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retorna todas as categorias existentes no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /RetornaCategorias
        ///
        /// </remarks>
        /// <returns>Uma lista de todas as categorias.</returns>
        /// <response code="200">Lista de categorias retornada com sucesso.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("RetornaCategorias")]
        [ProducesResponseType(typeof(IEnumerable<Categoria>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RetornaCategorias()
        {
            try
            {
                // retorna todas as categorias da base
                return Ok(await _categoriaService.RetornaCategorias());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Util.MensagensStrings.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Atualiza uma categoria existente no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /AtualizaCategoria
        ///     {
        ///         "CategoriaID": "00000000-0000-0000-0000-000000000000",
        ///         "Nome": "Categoria Atualizada",
        ///         "Descricao": "Descrição da categoria atualizada."
        ///     }
        ///
        /// </remarks>
        /// <param name="categoriaSelecionada">Os novos dados da categoria a serem atualizados.</param>
        /// <returns>A categoria atualizada.</returns>
        /// <response code="200">Categoria atualizada com sucesso.</response>
        /// <response code="400">Requisição inválida. Verifique os detalhes da solicitação.</response>
        /// <response code="404">Recurso não encontrado. A categoria especificada não foi encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("AtualizaCategoria")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizaCategoria([FromBody] Categoria categoriaSelecionada)
        {
            try
            {
                // Realiza a validação do objeto recebido
                ValidationResult validationResult = await _validator.ValidateAsync(categoriaSelecionada);

                // Caso o objeto não seja valido
                if (!validationResult.IsValid)
                {
                    // retorna um bad request com os erros
                    return BadRequest(validationResult.Errors);
                }

                // Realiza o update da categoria na base
                if (await _categoriaService.AtualizarCategoria(categoriaSelecionada))
                {
                    // Caso tenha conseguido, atualizar, retorna 200 com a categoria
                    return Ok(categoriaSelecionada);
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
        /// Deleta uma categoria existente no sistema com base no GUID fornecido.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /DeletaCategoria?guidUsuario=00000000-0000-0000-0000-000000000000
        ///
        /// </remarks>
        /// <param name="guidCategoria">O GUID da categoria a ser deletada.</param>
        /// <returns>Nenhum conteúdo.</returns>
        /// <response code="204">Categoria deletada com sucesso.</response>
        /// <response code="400">Requisição inválida. O GUID da categoria não foi fornecido corretamente.</response>
        /// <response code="404">Recurso não encontrado. A categoria especificada não foi encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("DeletaCategoria{guidCategoria}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletaCategoria(Guid guidCategoria)
        {
            try
            {
                // Caso o Guid esteja inválido, retorna um badrequest
                if (guidCategoria == Guid.Empty)
                {
                    return BadRequest(Util.MensagensStrings.RecursoFornecidoForaEsperado);
                }

                // Chama o serviço para deletar a categoria
                if (!await _categoriaService.DeletarCategoria(guidCategoria))
                {
                    // Caso não consiga deletar
                    return NotFound(Util.MensagensStrings.RecursoNaoEncontrado);
                }

                // Após deletar o usuário, retorna 204
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Util.MensagensStrings.ErroTentarDeletarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}