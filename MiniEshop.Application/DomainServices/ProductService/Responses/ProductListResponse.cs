namespace MiniEshop.Application.DomainServices.ProductService.Responses;

public record ProductListResponse(IEnumerable<ProductListResponse.ListItem> Items)
{
    public record ListItem(Guid Id, string Name, int Quantity, decimal Price);
}
