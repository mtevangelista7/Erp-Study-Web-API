using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Models.DTOs;
using ErpStudyWebAPI.Services.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Controllers
{
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
                await _authService.RealizaLogin(usuarioCadastroDto.NomeUsuario, usuarioCadastroDto.Senha);
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Erro ao tentar realizar login");
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
            
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> InsereUsuario(UsuarioCadastroDto usuarioCadastro)
        {
            Guid guid;
            
            try
            {
                guid = 
                    await _authService.RegistraUsuario
                        (new Usuario {NomeUsuario = usuarioCadastro.NomeUsuario}, usuarioCadastro.Senha);

                if (guid == Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Erro ao tentar cadastar usuario");
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
            
            return Ok(guid);
        }
    }
}