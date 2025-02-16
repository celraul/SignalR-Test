using Cel.SignalR.Application.Interfaces;
using Cel.SignalR.Domain.Entities;
using Cel.SignalR.Infra.EntityCore;

namespace Cel.SignalR.Infra;

// Testing UOW
public class UnitOfWork : IUnitOfWork
{
    private readonly MemoryDbContext _context;
    private readonly Dictionary<Type, object> _repositories = [];

    public UnitOfWork(MemoryDbContext context)
    {
        _context = context;
    }

    public IRepository<T> Repository<T>() where T : BaseEntity
    {
        if (!_repositories.ContainsKey(typeof(T)))
        {
            _repositories[typeof(T)] = new Repository<T>(_context);
        }

        return (IRepository<T>)_repositories[typeof(T)];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}