namespace Merchandising.Application.Models;

public class CreateProductRequestVM 
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public string CategoryName { get; set; }
    public int MinimumStockQuantity { get; set; }
    public int StockQuantity { get; set; }
}
