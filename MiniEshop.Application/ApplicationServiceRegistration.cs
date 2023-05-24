using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MiniEshop.Application.DomainServices.ProductImageService;
using MiniEshop.Application.DomainServices.ProductService;
using System.Reflection;

namespace MiniEshop.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductImageService, ProductImageService>();

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
