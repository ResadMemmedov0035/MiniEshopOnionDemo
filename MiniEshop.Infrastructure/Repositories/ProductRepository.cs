using Microsoft.EntityFrameworkCore;
using MiniEshop.Application.Repositories;
using MiniEshop.Domain.Entities;
using MiniEshop.Infrastructure.Repositories.Common;

namespace MiniEshop.Infrastructure.Repositories;

public class ProductRepository : Repository<Product, Guid>, IProductRepository
{
    public ProductRepository(DbContext context) : base(context) { }
}
