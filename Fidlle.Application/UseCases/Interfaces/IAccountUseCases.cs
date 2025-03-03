using Fidlle.Application.DTO;
using System.Security.Claims;

namespace Fidlle.Application.UseCases.Interfaces
{
    public interface IAccountUseCases
    {
        Task<ClaimsPrincipal?> LoginUser(LoginDto loginDto, string authScheme);
        Task<bool> RegisterUser(RegisterDto registerDto);

    }
}
