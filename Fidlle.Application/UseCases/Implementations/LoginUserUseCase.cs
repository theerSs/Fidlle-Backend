using Fidlle.Application.DTO;
using Fidlle.Application.Service.Interfaces;
using Fidlle.Application.UseCases.Interfaces;
using System.Security.Claims;

namespace Fidlle.Application.UseCases.Implementations
{
    public class LoginUserUseCase(IUserService userService, IClaimsService claimsService) : ILoginUserUseCase
    {
        public async Task<ClaimsPrincipal?> ExecuteAsync(LoginDto loginDto, string authScheme)
        {
            var userDto = await userService.AuthenticateAsync(loginDto.Username, loginDto.Password);
            if(userDto == null)
            {
                return null;
            }
            var claimsPrincipal = claimsService.CreateClaimsPrincipal(userDto.Username, authScheme);

            return claimsPrincipal;
        }
    }
}
