using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Models.DTOs;
using ErpStudyWebAPI.Services.AuthServices;
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
    [Route("api/[controller]")]
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

        [HttpPost("Login")]
        public async Task<IActionResult> RealizaLogin(UsuarioCadastroDto usuarioCadastroDto)
        {
            try
            {
                // Realiza o login do usuario e gera o token jwt
                string tokenAuth =
                    await _authService.RealizaLogin(usuarioCadastroDto.NomeUsuario, usuarioCadastroDto.Senha);

                // Caso tenha retornado algum token
                if (!string.IsNullOrWhiteSpace(tokenAuth))
                {
                    // Gera código 200 passando o token para o usuário
                    return Ok(tokenAuth);
                }

                // Caso não tenha conseguido gerar o token, retorna que o usuário não está autorizado
                return Unauthorized();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Erro ao tentar realizar login");
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsereUsuario(UsuarioCadastroDto usuarioCadastro)
        {
            try
            {
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
                // TODO aqui seria legal passar para o usuario que ele já pode estar cadastrado
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Erro ao tentar cadastar usuario");
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizaUsuario(UsuarioCadastroDto usuarioCadastroDto)
        {
            try
            {
                // realiza a validação da model
                ValidationResult validatorResult = await _validator.ValidateAsync(usuarioCadastroDto);

                if (!validatorResult.IsValid)
                {
                    // retorna 400 com os dados de erro
                    return BadRequest(validatorResult.Errors);
                }
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Erro ao tentar atualizar usuario");
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }

            // TODO: Implementar aqui após finalizar repository e service
            return null;
        }

        [HttpDelete]
        public async Task<IActionResult> DeletaUsuario(Guid guidUsuario)
        {
            try
            {
                // Caso o ID não tenha vindo corretamente
                if (guidUsuario == Guid.Empty)
                {
                    // aaaaaaaa
                }
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Erro ao tentar cadastar usuario");
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }

            // TODO: implementar aqui após finalizar o repository e service
            return null;
        }
    }
}