using identity_base_api.DTOs;
using Microsoft.AspNetCore.Identity;

namespace identity_base_api.Services;

public interface IUserService
{
    Task<IdentityResult> AddUserAsync(CreateUserDto obj);
    Task<GetUserDto?> GetUserByEmailAsync(string email);
    Task<GetUserDto?> GetUserByIdAsync(string id);
    Task<IdentityResult> UpdateUserAsync(UpdateUserDto dto, string userId);
    Task<IdentityResult> DeleteUserAsync(string userId);
}