using identity_base_api.DTOs;

namespace identity_base_api.Services;

public interface IAuthService
{
    Task<string> LoginAsync(LoginDto dto);
}