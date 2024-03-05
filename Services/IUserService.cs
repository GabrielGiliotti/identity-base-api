using identity_base_api.DTOs;

namespace identity_base_api.Services;

public interface IUserService
{
    Task AddUserAsync(CreateUserDto obj);
    Task<UserDto?> GetUserByIdAsync(int id);
    Task<IEnumerable<UserDto>> GetAllUsersAsync(int skip, int take);
    Task UpdateUserAsync(UpdateUserDto obj, int id);
    Task DeleteUserAsync(int id);
}