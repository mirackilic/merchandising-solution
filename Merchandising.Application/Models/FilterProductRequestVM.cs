namespace Merchandising.Application.Models;

public class FilterProductRequestVM
{
    public string? Seacrch { get; set; }
    public int? MinStockQuantity { get; set; }
    public int? MaxStockQuantity { get; set; }
}
