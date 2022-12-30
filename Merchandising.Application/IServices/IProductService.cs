using Merchandising.Application.Models;
using Merchandising.Domain.Entities;

namespace Merchandising.Application.IRepositories;

public interface IProductService
{
    Product? GetById(int id);
    IQueryable<Product> GetAll();
    IQueryable<Product> Filter(FilterProductRequestVM requestVM);
    Task<int> CreateAsync(CreateProductRequestVM requestVM);
    Task<int> UpdateAsync(UpdateProductRequestVM requestVM);
    Task DeleteAsync(int id);
}
