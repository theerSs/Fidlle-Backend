namespace Fidlle.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(string username, string email, string password);
        Task<Guid?> AuthenticateAsync(string email, string password);
    }
}
