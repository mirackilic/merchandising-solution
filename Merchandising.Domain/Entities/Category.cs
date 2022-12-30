using System.ComponentModel.DataAnnotations;
using Merchandising.Domain.Base.Entities;

namespace Merchandising.Domain.Entities;

public class Category : BaseEntity
{

    [Required]
    public string Name { get; set; }

    public int MinimumStockQuantity { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}
