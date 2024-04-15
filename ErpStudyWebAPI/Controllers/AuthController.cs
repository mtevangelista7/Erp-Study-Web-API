using ErpStudyWebAPI.Helpers;
using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Models.DTOs;
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
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> InsereUsuario(UsuarioCadastroDto usuarioCadastro)
        {
            Guid guid = Guid.Empty;
            
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
            }
            
            return Ok(guid);
        }
    }
}