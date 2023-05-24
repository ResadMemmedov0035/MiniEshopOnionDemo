using MiniEshop.Application.DomainServices.ProductService.Requests;
using MiniEshop.Application.DomainServices.ProductService.Responses;
using MiniEshop.Domain.Entities;
using System.Linq.Expressions;

namespace MiniEshop.Application.Mappers;

public static class ProductMapper
{
    public static readonly Expression<Func<Product, ProductSingleResponse>> ProjectToSingleResponse = p => new
    (
        p.Id, p.Name, p.Quantity, p.Price,
        p.Images.Select(img => new ProductSingleResponse.ImageListItem(img.Id, img.Path))
    );

    public static readonly Expression<Func<Product, ProductListResponse.ListItem>> ProjectToListResponseItem = p => new
    (
        p.Id, p.Name, p.Quantity, p.Price
    );

    public static Product MapToProduct(this ProductUpsertRequest request) => new()
    {
        Name = request.Name,
        Price = request.Price,
        Quantity = request.Quantity
    };

    public static void MapToProduct(this ProductUpsertRequest request, Product product)
    {
        product.Name = request.Name;
        product.Price = request.Price;
        product.Quantity = request.Quantity;
    }

    public static ProductUpsertRequest MapToUpsertRequest(this ProductSingleResponse response) 
    {
        return new(response.Name, response.Quantity, response.Price);
    }
}