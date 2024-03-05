using identity_base_api.Models;

namespace identity_base_api.Repositories;

public interface IUserRepository
{
    Task AddAsync(User obj);
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync(int skip, int take);
    Task UpdateAsync(User obj, int id);
    Task RemoveAsync(int id);
}