using Fidlle.Application.DTO;
using Fidlle.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

namespace Fidlle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAntiforgery antiforgery, IRegisterUserUseCase registerUserUseCase, ILoginUserUseCase loginUserUseCase) : ControllerBase
    {

        [HttpGet("csrf-token")]
        public IActionResult GetCsrfToken()
        {
            var tokens = antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Headers.Append("X-CSRF-TOKEN", tokens.RequestToken);
            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await registerUserUseCase.ExecuteAsync(registerDto);
            if(!result)
            {
                return BadRequest();
            }

            return Created();
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var userDto = await loginUserUseCase.ExecuteAsync(loginDto);
            if (userDto == null)
            {
                return Unauthorized();
            };

            HttpContext.Session.SetString("Username", userDto.Username);

            return Ok(userDto);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return NoContent();
        }
    }
}
