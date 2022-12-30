namespace Merchandising.Application.Models;

public class CreateProductRequestVM : BaseProductVM
{
}

public class UpdateProductRequestVM : BaseProductVM
{
    public int Id { get; set; }
}

public class GetProductsRequestVM
{
    public string? Search { get; set; }
}

public class GetProductsResponseVM : BaseProductVM
{
}

public class BaseProductVM
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int MinimumStockQuantity { get; set; }
    public int StockQuantity { get; set; }
}

public class FilterProductRequestVM
{
    public string? Seacrch { get; set; }
    public int? MinStockQuantity { get; set; }
    public int? MaxStockQuantity { get; set; }
}
