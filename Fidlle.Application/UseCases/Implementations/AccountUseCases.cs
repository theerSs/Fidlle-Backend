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
            var isAuthenticated = await userService.AuthenticateAsync(loginDto.Email, loginDto.Password);
            if (!isAuthenticated)
            {
                return null;
            }
            var claimsPrincipal = claimsService.CreateClaimsPrincipal(loginDto.Email, authScheme);

            return claimsPrincipal;
        }

        public async Task<bool> RegisterUser(RegisterDto registerDto)
        {
            return await userService.CreateUserAsync(registerDto.Username, registerDto.Email, registerDto.Password);
        }
    }
}
