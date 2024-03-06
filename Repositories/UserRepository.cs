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
}