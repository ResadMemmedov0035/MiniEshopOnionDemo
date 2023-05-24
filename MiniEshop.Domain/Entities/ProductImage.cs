using MiniEshop.Domain.Entities.Common;

namespace MiniEshop.Domain.Entities;

public class ProductImage : Entity
{
    public string Path { get; set; } = string.Empty;
    public bool IsShowcase { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
