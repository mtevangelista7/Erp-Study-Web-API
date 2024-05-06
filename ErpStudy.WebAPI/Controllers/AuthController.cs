using ErpStudy.Application.DTOs.Users;
using ErpStudy.Application.Help;
using ErpStudy.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErpStudy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ILogger<AuthController> logger) : ControllerBase
    {
        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken(CreateUserDTO createUserDto,
            IAuthenticationService authenticationService)
        {
            try
            {
                string accessToken =
                    await authenticationService.GenerateAccessToken(createUserDto.Email, createUserDto.Password);

                if (accessToken is null)
                {
                    return BadRequest();
                }

                return Ok(accessToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, Helper.MessageInfo.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}