using Fidlle.Application.DTO;

namespace Fidlle.Application.UseCases.Interfaces
{
    public interface IRegisterUserUseCase
    {
        Task<bool> ExecuteAsync(RegisterDto registerDto);
    }
}
