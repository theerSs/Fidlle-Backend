using Fidlle.Application.DTO;

namespace Fidlle.Application.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(string username, string password);
        Task<UserDto?> AuthenticateAsync(string username, string password);
    }
}
