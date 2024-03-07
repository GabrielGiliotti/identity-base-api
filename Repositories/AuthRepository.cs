using identity_base_api.Models;
using Microsoft.AspNetCore.Identity;

namespace identity_base_api.Repositories;

public class AuthRepository : IAuthRepository
{
    private SignInManager<User> _signInManager;
    
    public AuthRepository(SignInManager<User> signInManager) 
    {
        _signInManager = signInManager;
    }

    public async Task<SignInResult> LoginAsync(Login obj)
    {
        return await _signInManager.PasswordSignInAsync(obj.Username, obj.Password, false, false);
    }

    public User? GetAuthenticatedUser(Login obj)
    {
        return _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == obj.Username.ToUpper());
    }
}