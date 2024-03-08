using identity_base_api.Models;
using Microsoft.AspNetCore.Identity;

namespace identity_base_api.Repositories;

public class UserRepository : IUserRepository
{
    private UserManager<User> _userManager;
    
    public UserRepository(UserManager<User> userManager) 
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> AddUserAsync(User obj, string password)
    {
        return await _userManager.CreateAsync(obj, password);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<User?> GetUserByIdAsync(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    public async Task<IdentityResult> UpdateUserAsync(User user)
    {
        return await _userManager.UpdateAsync(user);
    }

    public async Task<IdentityResult> DeleteUserAsync(User user)
    {
        return await _userManager.DeleteAsync(user);
    }
}