using Merchandising.Domain.Base.Entities;
using Merchandising.Domain.Context;

namespace Merchandising.Domain.IRepositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MerchandisingDbContext _context;

    public UnitOfWork(MerchandisingDbContext context)
    {
        _context = context;
    }

    public IRepository<T> GetRepository<T>() where T : BaseEntity
    {
        return new Repository<T>(_context);
    }


    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
