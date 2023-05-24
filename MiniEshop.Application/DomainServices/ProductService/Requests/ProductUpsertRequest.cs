namespace MiniEshop.Application.DomainServices.ProductService.Requests;

// Create/Update request
public record ProductUpsertRequest(string Name, int Quantity, decimal Price);
