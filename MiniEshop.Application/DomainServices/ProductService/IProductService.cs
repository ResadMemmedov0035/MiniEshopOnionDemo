using MiniEshop.Application.DomainServices.ProductService.Requests;
using MiniEshop.Application.DomainServices.ProductService.Responses;

namespace MiniEshop.Application.DomainServices.ProductService;

public interface IProductService
{
    ProductSingleResponse GetById(Guid id);
    ProductListResponse GetList();
    void Create(ProductUpsertRequest request);
    void Update(Guid id, ProductUpsertRequest request);
    void Delete(Guid id);
}
