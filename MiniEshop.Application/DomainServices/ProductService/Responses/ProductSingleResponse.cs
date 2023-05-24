namespace MiniEshop.Application.DomainServices.ProductService.Responses;

public record ProductSingleResponse(Guid Id, string Name, int Quantity, decimal Price, IEnumerable<ProductSingleResponse.ImageListItem> Images)
{
    public record ImageListItem(Guid Id, string Path)
    {
        public string Path { get; set; } = Path;
    }
}
