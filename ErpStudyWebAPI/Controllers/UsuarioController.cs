using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Models.DTOs;
using ErpStudyWebAPI.Services.AuthServices;
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

        public UsuarioController(ILogger<UsuarioController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
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
    }
}