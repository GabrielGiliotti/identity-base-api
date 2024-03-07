using identity_base_api.Models;
using Microsoft.AspNetCore.Identity;

namespace identity_base_api.Repositories;

public interface IAuthRepository
{
    Task<SignInResult> LoginAsync(Login obj);
}