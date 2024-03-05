using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace identity_base_api.Infrastructure.Database;

public class Repository<T> : ControllerBase, IRepository<T> where T:class
{
    private readonly DbSet<T> _dbSet;
    private readonly IUnitOfwork _unitOfWork;

    public Repository(IUnitOfwork unitOfwork)
    {
        _unitOfWork = unitOfwork;
        _dbSet = _unitOfWork.Context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Create(T entity)
    {
        _dbSet.Add(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task Update(int id, T entity)
    {
        var obj = await _dbSet.FindAsync(id);

        if (obj != null)
            _unitOfWork.Context.Entry(obj).CurrentValues.SetValues(entity);

        try
        {
            await _unitOfWork.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }
    }

    public async Task Delete(int id)
    {
        var data = await _dbSet.FindAsync(id);
        
        if (data != null)
        {
            _dbSet.Remove(data);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}