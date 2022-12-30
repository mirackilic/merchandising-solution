using System.Linq.Expressions;
using Merchandising.Domain.Base.Entities;

namespace Merchandising.Domain.IRepositories;

public interface IRepository<T> where T : IBaseEntity
{
    IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    T FindOne(Expression<Func<T, bool>> predicate);
    IQueryable<T> GetAll();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
}
