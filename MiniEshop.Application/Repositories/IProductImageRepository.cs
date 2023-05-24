using MiniEshop.Application.Repositories.Common;
using MiniEshop.Domain.Entities;

namespace MiniEshop.Application.Repositories;

public interface IProductImageRepository : IRepository<ProductImage, Guid> { }