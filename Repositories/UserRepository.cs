using identity_base_api.Infrastructure.Database;
using identity_base_api.Models;

namespace identity_base_api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IRepository<User> _repo;
    
    public UserRepository(IRepository<User> repo) 
    {
        _repo = repo;
    }

    public async Task AddAsync(User obj)
    {
        await _repo.Create(obj);
    }

    public async Task<IEnumerable<User>> GetAllAsync(int skip, int take)
    {
        var users = await _repo.GetAll();

        //if(theaterName == null)
            
        return users.Skip(skip).Take(take);

        // return movies.Where(m => m.Sessions != null && m.Sessions.Any(s => s.MovieTheater != null && s.MovieTheater.Name == theaterName));
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _repo.GetById(id);
    }

    public async Task RemoveAsync(int id)
    {
        await _repo.Delete(id);
    }

    public async Task UpdateAsync(User obj, int id)
    {
        await _repo.Update(id, obj);
    }
}