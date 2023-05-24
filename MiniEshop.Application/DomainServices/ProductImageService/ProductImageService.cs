using Microsoft.AspNetCore.Http;
using MiniEshop.Application.DomainServices.ProductImageService.Responses;
using MiniEshop.Application.Guards;
using MiniEshop.Application.Repositories;
using MiniEshop.Application.Storages;
using MiniEshop.Domain.Entities;

namespace MiniEshop.Application.DomainServices.ProductImageService;

public class ProductImageService : IProductImageService
{
    private readonly IProductImageRepository _productImageRepository;
    private readonly IProductRepository _productRepository;
    private readonly IStorage _storage;

    public ProductImageService(IProductImageRepository productImageRepository,
        IProductRepository productRepository,
        IStorage storage)
    {
        _productImageRepository = productImageRepository;
        _productRepository = productRepository;
        _storage = storage;
    }

    public UploadImagesResponse UploadImages(Guid productId, IFormFileCollection files)
    {
        // check if all files are image
        foreach (var file in files)
            FileGuard.MustImageFormat(file.FileName);

        // check if the product is exists
        Product? product = _productRepository.FindById(productId);
        product.AgainstNull();

        // upload images to file storage (eg: local, azure, aws and cloudinary servers)
        IEnumerable<string> paths = _storage.UploadImages("product-images", files.Select(f => f.OpenReadStream()));

        // save images data to database
        IEnumerable<ProductImage> images = paths.Select(path => new ProductImage { Path = path, ProductId = productId });
        _productImageRepository.Create(images);
        _productImageRepository.Save();

        return new(paths.Select(path => $"{_storage.ServerUrl}/{path}"));
    }

    public SetShowcaseImageResponse SetShowcaseImage(Guid productImageId)
    {
        // find the image intended to be showcase
        ProductImage? intendedImage = _productImageRepository.FindById(productImageId);
        Guard.AgainstNull(intendedImage);

        // find the current showcase image
        ProductImage? currentImage = _productImageRepository.FindByFilter(i => i.ProductId == intendedImage!.ProductId && i.IsShowcase);

        // there could be no current showcase
        if (currentImage is not null)
            currentImage.IsShowcase = false;

        intendedImage!.IsShowcase = true;
        _productImageRepository.Save();

        return new(intendedImage.Id, intendedImage.ProductId);
    }
}
