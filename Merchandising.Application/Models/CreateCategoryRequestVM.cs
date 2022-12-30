namespace Merchandising.Application.Models;

public class CreateCategoryRequestVM : BaseCategoryVM
{
}

public class UpdateCategoryRequestVM : BaseCategoryVM
{
}

public class BaseCategoryVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MinimumStockQuantity { get; set; }
}
