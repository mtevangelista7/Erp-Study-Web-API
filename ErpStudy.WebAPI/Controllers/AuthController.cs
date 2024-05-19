using ErpStudy.Application.DTOs.Auth;
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
        public async Task<IActionResult> GenerateToken(GetTokenUser getTokenUser,
            IAuthenticationService authenticationService)
        {
            try
            {
                string accessToken =
                    await authenticationService.GenerateAccessToken(getTokenUser.Email, getTokenUser.Password);

                if (String.IsNullOrWhiteSpace(accessToken))
                {
                    return NotFound();
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