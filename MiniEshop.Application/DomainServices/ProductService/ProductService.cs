using FluentValidation;
using MiniEshop.Application.DomainServices.ProductService.Requests;
using MiniEshop.Application.DomainServices.ProductService.Responses;
using MiniEshop.Application.Guards;
using MiniEshop.Application.Mappers;
using MiniEshop.Application.Repositories;
using MiniEshop.Application.Storages;
using MiniEshop.Domain.Entities;

namespace MiniEshop.Application.DomainServices.ProductService;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IStorage _storage;
    private readonly IValidator<ProductUpsertRequest> _upsertValidator;

    public ProductService(
        IProductRepository productRepository, 
        IStorage storage,
        IValidator<ProductUpsertRequest> validator)
    {
        _productRepository = productRepository;
        _storage = storage;
        _upsertValidator = validator;
    }

    public ProductSingleResponse GetById(Guid id)
    {
        ProductSingleResponse? response = _productRepository.Query(p => p.Id == id, tracking: false)
            .Select(ProductMapper.ProjectToSingleResponse)
            .FirstOrDefault();

        response.AgainstNull("Product");

        foreach (var img in response!.Images)
            img.Path = $"{_storage.ServerUrl}/{img.Path}";

        return response;
    }

    public ProductListResponse GetList()
    {
        var list = _productRepository.Query(tracking: false)
            .Select(ProductMapper.ProjectToListResponseItem)
            .ToList();

        return new(list);
    }

    public void Create(ProductUpsertRequest request)
    {
        _upsertValidator.ValidateAndThrow(request);

        _productRepository.Create(request.MapToProduct());
        _productRepository.Save();
    }

    public void Update(Guid id, ProductUpsertRequest request)
    {
        _upsertValidator.ValidateAndThrow(request);

        Product? product = _productRepository.FindById(id);

        request.MapToProduct(product.AgainstNull());
        _productRepository.Save();
    }

    public void Delete(Guid id)
    {
        Product? product = _productRepository.FindById(id);

        _productRepository.Delete(product.AgainstNull());
        _productRepository.Save();
    }
}