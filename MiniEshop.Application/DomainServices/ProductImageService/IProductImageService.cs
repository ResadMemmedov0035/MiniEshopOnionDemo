using Microsoft.AspNetCore.Http;
using MiniEshop.Application.DomainServices.ProductImageService.Responses;

namespace MiniEshop.Application.DomainServices.ProductImageService;

public interface IProductImageService
{
    UploadImagesResponse UploadImages(Guid productId, IFormFileCollection files);
    SetShowcaseImageResponse SetShowcaseImage(Guid productImageId);
}
