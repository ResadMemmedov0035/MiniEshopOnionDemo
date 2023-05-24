using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiniEshop.Application.Repositories;
using MiniEshop.Application.Storages;
using MiniEshop.Infrastructure.Contexts;
using MiniEshop.Infrastructure.Repositories;
using MiniEshop.Infrastructure.Storages;

namespace MiniEshop.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<DbContext, ApplicationDbContext>(options => 
        {
            options.UseInMemoryDatabase("MiniEshopInMemoryDb");
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductImageRepository, ProductImageRepository>();

        services.AddSingleton<IStorage, LocalStorage>();

        return services;
    }
}
