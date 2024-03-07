using identity_base_api.Models;

namespace identity_base_api.Services;

public interface ITokenService
{
    string GenerateToken(User obj);
}