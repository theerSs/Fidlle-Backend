using Fidlle.Application.DTO;
using Fidlle.Application.Service.Interfaces;
using Fidlle.Application.UseCases.Interfaces;
using Fidlle.Domain.Entities;

namespace Fidlle.Application.UseCases.Implementations
{
    public class RegisterUseCase(IUserService userService) : IRegisterUserUseCase
    {
        public async Task<bool> ExecuteAsync(RegisterDto registerDto)
        {
            return await userService.CreateUserAsync(registerDto.Username, registerDto.Password);
        }
    }
}
