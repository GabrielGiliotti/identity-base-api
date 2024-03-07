using identity_base_api.DTOs;
using Microsoft.AspNetCore.Identity;

namespace identity_base_api.Services;

public interface IAuthService
{
    Task<SignInResult> LoginAsync(LoginDto dto);
}