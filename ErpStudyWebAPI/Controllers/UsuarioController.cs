using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Models.DTOs;
using ErpStudyWebAPI.Services.AuthServices;
using ErpStudyWebAPI.Utilities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Controllers
{
    [Authorize]
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IAuthService _authService;
        private readonly IValidator<UsuarioCadastroDto> _validator;

        public UsuarioController(ILogger<UsuarioController> logger, IAuthService authService,
            IValidator<UsuarioCadastroDto> validator)
        {
            _logger = logger;
            _authService = authService;
            _validator = validator;
        }

        /// <summary>
        /// Gera um token de acesso para o usuário.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /gerartoken
        ///     {
        ///         "NomeUsuario": "exemplo",
        ///         "Senha": "exemplo123"
        ///     }
        ///
        /// </remarks>
        /// <param name="usuarioCadastroDto">Os dados do usuário para autenticação.</param>
        /// <returns>O token de acesso gerado.</returns>
        /// <response code="200">Token de acesso gerado com sucesso.</response>
        /// <response code="401">Acesso não autorizado. Verifique suas credenciais e tente novamente.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("GerarTokenAcesso")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GerarTokenAcesso(UsuarioCadastroDto usuarioCadastroDto)
        {
            try
            {
                // Realiza o login do usuario e gera o token jwt
                string tokenAuth =
                    await _authService.GeraTokenAcesso(usuarioCadastroDto.NomeUsuario, usuarioCadastroDto.Senha);

                // Caso tenha retornado algum token
                if (!string.IsNullOrWhiteSpace(tokenAuth))
                {
                    // Gera código 200 passando o token para o usuário
                    return Ok(tokenAuth);
                }

                // Caso não tenha conseguido gerar o token, retorna que o usuário não está autorizado
                return Unauthorized(Util.MensagensStrings.AcessoNaoAutorizado);
            }
            catch (Exception err)
            {
                _logger.LogError(err, Util.MensagensStrings.ErroTentarGerarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        /// <summary>
        /// Insere um novo usuário no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /cadastrousuario
        ///     {
        ///         "NomeUsuario": "novousuario",
        ///         "Senha": "senhanova123"
        ///     }
        ///
        /// </remarks>
        /// <param name="usuarioCadastro">Os dados do usuário a serem cadastrados.</param>
        /// <returns>O token de acesso gerado para o novo usuário.</returns>
        /// <response code="200">Usuário cadastrado com sucesso.</response>
        /// <response code="400">Requisição inválida. Verifique os detalhes da solicitação.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("CadastroUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsereUsuario(UsuarioCadastroDto usuarioCadastro)
        {
            try
            {
                // Valida a model recebida
                ValidationResult validatorResult = await _validator.ValidateAsync(usuarioCadastro);

                // Caso não passe na validação retorna um bad request com os erros
                if (!validatorResult.IsValid)
                {
                    return BadRequest(validatorResult.Errors);
                }

                // Realiza o cadastro do usuario
                string tokenUsuarioCadastrado =
                    await _authService.RegistraUsuario
                        (new Usuario { NomeUsuario = usuarioCadastro.NomeUsuario }, usuarioCadastro.Senha);

                // Verifica se o cadastro foi feito com sucesso (o token foi retornado para o usuário)
                if (!string.IsNullOrWhiteSpace(tokenUsuarioCadastrado))
                {
                    return Ok(tokenUsuarioCadastrado);
                }

                // Caso o cadastrado tenha falhado, retorna 400
                return BadRequest(Util.MensagensStrings.ErroTentarCadastrarRecurso);
            }
            catch (Exception err)
            {
                _logger.LogError(err, Util.MensagensStrings.ErroTentarCadastrarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        /// <summary>
        /// Atualiza as informações de um usuário existente no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /AtualizaUsuario
        ///     {
        ///         "NomeUsuario": "novousuarionome",
        ///         "Senha": "novasenha123"
        ///     }
        ///
        /// </remarks>
        /// <param name="usuarioCadastroDto">Os novos dados do usuário a serem atualizados.</param>
        /// <returns>O usuário atualizado.</returns>
        /// <response code="200">Usuário atualizado com sucesso.</response>
        /// <response code="400">Requisição inválida. Verifique os detalhes da solicitação.</response>
        /// <response code="404">Recurso não encontrado. O usuário especificado não foi encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("AtualizaUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizaUsuario(UsuarioCadastroDto usuarioCadastroDto)
        {
            try
            {
                // Realiza a validação da model
                ValidationResult validatorResult = await _validator.ValidateAsync(usuarioCadastroDto);

                if (!validatorResult.IsValid)
                {
                    // retorna 400 com os dados de erro
                    return BadRequest(validatorResult.Errors);
                }

                // Realiza o update do usuario na base
                if (await _authService.AtualizaInfoUsuario(usuarioCadastroDto))
                {
                    // Caso tenha conseguido atualizar, retorna 200 com o item atualizado
                    return Ok(usuarioCadastroDto);
                }

                // Caso não tenha conseguido atualizar, retorna 404 com a mensagem
                return NotFound(Util.MensagensStrings.RecursoNaoEncontrado);
            }
            catch (Exception err)
            {
                _logger.LogError(err, Util.MensagensStrings.ErroTentarAtualizarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        /// <summary>
        /// Deleta um usuário existente no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /DeletaUsuario?guidUsuario=00000000-0000-0000-0000-000000000000
        ///
        /// </remarks>
        /// <param name="guidUsuario">O GUID do usuário a ser deletado.</param>
        /// <returns>Nenhum conteúdo.</returns>
        /// <response code="204">Usuário deletado com sucesso.</response>
        /// <response code="400">Requisição inválida. O GUID do usuário não foi fornecido corretamente.</response>
        /// <response code="404">Recurso não encontrado. O usuário especificado não foi encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("DeletaUsuario{guidUsuario}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletaUsuario(Guid guidUsuario)
        {
            try
            {
                // Caso o ID não tenha vindo corretamente
                if (guidUsuario == Guid.Empty)
                {
                    return BadRequest(Util.MensagensStrings.RecursoFornecidoForaEsperado);
                }

                // Chama o serviço para deletar o usuario
                if (!await _authService.DeletaUsuario(guidUsuario))
                {
                    // Caso não consiga deletar
                    return NotFound(Util.MensagensStrings.RecursoNaoEncontrado);
                }

                // Após deletar o usuário, retorna 204
                return NoContent();
            }
            catch (Exception err)
            {
                _logger.LogError(err, Util.MensagensStrings.ErroTentarDeletarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }
    }
}