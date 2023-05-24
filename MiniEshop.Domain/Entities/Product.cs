using MiniEshop.Domain.Entities.Common;

namespace MiniEshop.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public ICollection<ProductImage> Images { get; set; } = null!;
}
