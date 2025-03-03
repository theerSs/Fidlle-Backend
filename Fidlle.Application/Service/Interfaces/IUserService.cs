using Fidlle.Application.DTO;

namespace Fidlle.Application.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(string username, string email, string password);
        Task<Guid?> AuthenticateAsync(string email, string password);
    }
}
