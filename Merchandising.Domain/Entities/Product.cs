using System.ComponentModel.DataAnnotations;
using Merchandising.Domain.Base.Entities;

namespace Merchandising.Domain.Entities;

public class Product : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    public string? Description { get; set; }
    [Required]
    public bool IsLive { get; set; }
    [Required]
    public int CategoryId { get; set; }

    public int StockQuantity { get; set; }

    public virtual Category Category { get; set; }
}
