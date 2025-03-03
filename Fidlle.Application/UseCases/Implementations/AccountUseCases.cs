using Fidlle.Application.DTO;
using Fidlle.Application.Service.Interfaces;
using Fidlle.Application.UseCases.Interfaces;
using System.Security.Claims;


namespace Fidlle.Application.UseCases.Implementations
{
    public class AccountUseCases(IUserService userService, IClaimsService claimsService) : IAccountUseCases
    {
        public async Task<ClaimsPrincipal?> LoginUser(LoginDto loginDto, string authScheme)
        {
            var userDto = await userService.AuthenticateAsync(loginDto.Username, loginDto.Password);
            if (userDto == null)
            {
                return null;
            }
            var claimsPrincipal = claimsService.CreateClaimsPrincipal(userDto.Username, authScheme);

            return claimsPrincipal;
        }

        public async Task<bool> RegisterUser(RegisterDto registerDto)
        {
            return await userService.CreateUserAsync(registerDto.Username, registerDto.Password);
        }
    }
}
