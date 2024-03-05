namespace identity_base_api.Infrastructure.Database;

public class UnitOfwork : IUnitOfwork
{
    private readonly Context _context;
    private bool _disposed = false;

    public UnitOfwork(Context context)
    {
        _context = context;
    }
    public Context Context => _context;

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
