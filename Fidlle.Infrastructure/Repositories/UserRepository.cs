using Fidlle.Application.IRepositories;
using Fidlle.Domain.Entities;
using Fidlle.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Fidlle.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task CreateUserAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
