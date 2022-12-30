using Merchandising.Application.IRepositories;
using Merchandising.Application.Models;
using Merchandising.Domain.Entities;
using Merchandising.Domain.IRepositories;

namespace Merchandising.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Product? GetById(int id)
    {
        return _unitOfWork.GetRepository<Product>().FindOne(x => x.Id == id);
    }

    public IQueryable<Product> Filter(FilterProductRequestVM requestVM)
    {
        var search = requestVM.Seacrch?.ToLower().Trim();

        var products = _unitOfWork.GetRepository<Product>().Find(x =>
           (string.IsNullOrEmpty(search) || x.Title.ToLower().Contains(search))
        && (string.IsNullOrEmpty(search) || !string.IsNullOrEmpty(x.Description) && x.Description.ToLower().Contains(search))
        && (string.IsNullOrEmpty(search) || x.Category.Name.ToLower().Contains(search))
        && (requestVM.MinStockQuantity == null || x.StockQuantity >= requestVM.MinStockQuantity)
        && (requestVM.MaxStockQuantity == null || x.StockQuantity <= requestVM.MaxStockQuantity)).ToList().AsQueryable();

        return products;
    }

    public IQueryable<Product> GetAll() 
    {
        return _unitOfWork.GetRepository<Product>().Find(x => x.IsLive).ToList().AsQueryable();
    }

    public async Task<int> CreateAsync(CreateProductRequestVM requestVM)
    {
        var product = Product(requestVM);

        // await _unitOfWork.GetRepository<Category>().CreateAsync(product.Category);

        await _unitOfWork.GetRepository<Product>().CreateAsync(product);

        return await _unitOfWork.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(UpdateProductRequestVM requestVM)
    {
        var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(requestVM.Id);

        if (product is null)
            throw new ApplicationException("Product is not exist!");

        product.Title = requestVM.Title;
        product.Description = requestVM.Description;
        product.Category.Name = requestVM.CategoryName;
        product.StockQuantity = requestVM.StockQuantity;
        product.Category.MinimumStockQuantity = requestVM.MinimumStockQuantity;
        product.IsLive = product.StockQuantity >= product.Category.MinimumStockQuantity;

        _unitOfWork.GetRepository<Product>().Update(product);

        return await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(id);

        if (product is null)
            throw new ApplicationException("Product is not exist!");

        var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(product.CategoryId);

        if (category is null)
            throw new ApplicationException("Category is not exist!");

        _unitOfWork.GetRepository<Product>().Delete(product);
        _unitOfWork.GetRepository<Category>().Delete(category);

        await _unitOfWork.SaveChangesAsync();
    }

    #region Helpers

    private Product Product(CreateProductRequestVM model)
    {
        var product = new Product
        {
            Title = model.Title,
            Category = new Category
            {
                Name = model.CategoryName,
                MinimumStockQuantity = model.MinimumStockQuantity
            },
            Description = model.Description,
            StockQuantity = model.StockQuantity
        };

        product.IsLive = product.StockQuantity >= product.Category.MinimumStockQuantity;

        return product;
    }

    #endregion
}
