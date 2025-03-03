﻿using Fidlle.Domain.Entities;

namespace Fidlle.Application.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User user);
        Task SaveChangesAsync();
    }
}
