using Fidlle.Application.DTO;
using System.Security.Claims;

namespace Fidlle.Application.UseCases.Interfaces
{
    public interface ILoginUserUseCase
    {
        Task<ClaimsPrincipal?> ExecuteAsync(LoginDto loginDto, string authScheme);
    }
}
