using Fidlle.Application.DTO;
using Fidlle.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

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
            var claimsPrinciple = await loginUserUseCase.ExecuteAsync(loginDto, CookieAuthenticationDefaults.AuthenticationScheme);
               
            if(claimsPrinciple == null)
            {
                return Unauthorized();
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrinciple);

            return Ok();
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

    }
}
