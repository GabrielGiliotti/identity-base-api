using identity_base_api.Models;
using Microsoft.AspNetCore.Identity;

namespace identity_base_api.Repositories;

public interface IUserRepository
{
    Task<IdentityResult> AddUserAsync(User obj, string password);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByIdAsync(string id);
    Task<IdentityResult> UpdateUserAsync(User user);
    Task<IdentityResult> DeleteUserAsync(User user);
}