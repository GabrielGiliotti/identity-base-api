namespace identity_base_api.Infrastructure.Database;

public interface IRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T?> GetById(int id);
    public Task Create(T entity);
    public Task Update(int id, T entity);
    public Task Delete(int id);
}