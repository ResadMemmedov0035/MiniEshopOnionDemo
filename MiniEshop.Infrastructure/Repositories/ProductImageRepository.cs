using Microsoft.EntityFrameworkCore;
using MiniEshop.Application.Repositories;
using MiniEshop.Domain.Entities;
using MiniEshop.Infrastructure.Repositories.Common;

namespace MiniEshop.Infrastructure.Repositories;

public class ProductImageRepository : Repository<ProductImage, Guid>, IProductImageRepository
{
    public ProductImageRepository(DbContext context) : base(context) { }
}
