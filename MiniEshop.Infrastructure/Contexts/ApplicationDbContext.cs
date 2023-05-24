using Microsoft.EntityFrameworkCore;
using MiniEshop.Domain.Entities;

namespace MiniEshop.Infrastructure.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductImage> ProductImages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(_productSeedData);
        modelBuilder.Entity<ProductImage>().HasData(_productImageSeedData);

        base.OnModelCreating(modelBuilder);
    }

    private static readonly Product[] _productSeedData = new[]
    {
        new Product { Id = Guid.NewGuid(), Name = "Tablet", Price = 1000, Quantity = 50 },
        new Product { Id = Guid.NewGuid(), Name = "Phone", Price = 800, Quantity = 100 }
    };

    private static readonly ProductImage[] _productImageSeedData = new[]
    {
        new ProductImage { Id = Guid.NewGuid(), Path = "product-images/tablet1.jpg", ProductId = _productSeedData[0].Id },
        new ProductImage { Id = Guid.NewGuid(), Path = "product-images/tablet2.jpg", ProductId = _productSeedData[0].Id },
        new ProductImage { Id = Guid.NewGuid(), Path = "product-images/phone1.jpg", ProductId = _productSeedData[1].Id },
        new ProductImage { Id = Guid.NewGuid(), Path = "product-images/phone2.jpg", ProductId = _productSeedData[1].Id }
    };
}
