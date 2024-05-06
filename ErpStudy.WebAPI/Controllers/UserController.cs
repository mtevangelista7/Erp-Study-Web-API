using ErpStudy.Application.DTOs.Users;
using ErpStudy.Application.Help;
using ErpStudy.Application.Interfaces.UsesCases.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErpStudy.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ILogger<UserController> logger) : ControllerBase
    {
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(CreateUserDTO request,
            ICreateUserUseCase createUserUseCase)
        {
            try
            {
                var result = await createUserUseCase.ExecuteAsync(request);

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                return Created(nameof(AddUser), result.Value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, Helper.MessageInfo.ErroTentarCadastrarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetProductById={getUserByIdUseCase}")]
        public async Task<IActionResult> GetUserById(GetUserByIdDTO request,
            IGetUserByIdUseCase getUserByIdUseCase)
        {
            try
            {
                var result = await getUserByIdUseCase.ExecuteAsync(request);

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                if (result.Value is null)
                {
                    return NotFound();
                }

                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, Helper.MessageInfo.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(IGetAllUsersUseCase getAllUsersUseCase)
        {
            try
            {
                var result = await getAllUsersUseCase.ExecuteAsync();

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                if (result.Value is null || result.Value.Count == 0)
                {
                    return NotFound();
                }

                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, Helper.MessageInfo.ErroTentarObterRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO request,
            IUpdateUserUseCase updateUserUseCase)
        {
            try
            {
                var result = await updateUserUseCase.ExecuteAsync(request);

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                if (result.Value is null)
                {
                    return NotFound();
                }

                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, Helper.MessageInfo.ErroTentarAtualizarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserDTO request,
            IDeleteUserUseCase deleteUserUseCase)
        {
            try
            {
                var result = await deleteUserUseCase.ExecuteAsync(request);

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, Helper.MessageInfo.ErroTentarDeletarRecurso);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}