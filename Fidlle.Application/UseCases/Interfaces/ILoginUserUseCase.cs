using Fidlle.Application.DTO;

namespace Fidlle.Application.UseCases.Interfaces
{
    public interface ILoginUserUseCase
    {
        Task<UserDto?> ExecuteAsync(LoginDto loginDto);
    }
}
