using System.Threading.Tasks;
using Merchandising.Domain.Base.Entities;

namespace Merchandising.Domain.IRepositories;

public interface IUnitOfWork
{
    IRepository<T> GetRepository<T>() where T : BaseEntity;
    Task<int> SaveChangesAsync();
    int SaveChanges();
}
    