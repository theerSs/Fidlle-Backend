using Fidlle.Application.DTO;
using Fidlle.Application.Service.Interfaces;
using Fidlle.Application.UseCases.Interfaces;

namespace Fidlle.Application.UseCases.Implementations
{
    public class LoginUserUseCase(IUserService userService) : ILoginUserUseCase
    {
        public async Task<UserDto?> ExecuteAsync(LoginDto loginDto)
        {
            return await userService.AuthenticateAsync(loginDto.Username, loginDto.Password);
        }
    }
}
