using System.Linq.Expressions;
using Merchandising.Domain.Base.Entities;
using Merchandising.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace Merchandising.Domain.IRepositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    #region Settings

    private readonly MerchandisingDbContext _context;
    private DbSet<T> _entity;

    public Repository(MerchandisingDbContext context)
    {
        _context = context;
        _entity = context.Set<T>();
    }

    protected DbSet<T> Table => _entity ?? (_entity = _context.Set<T>());

    #endregion

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return Table.Where(predicate).AsQueryable();
    }

    public T FindOne(Expression<Func<T, bool>> predicate)
    {
        return Table.FirstOrDefault(predicate);
    }

    public IQueryable<T> GetAll()
    {
        return Table.AsQueryable();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await Table.FindAsync(id);
    }

    public async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public void Create(T entity)
    {
        Table.Add(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }

    public void Update(T entity)
    {
        Table.Update(entity);
    }
}
