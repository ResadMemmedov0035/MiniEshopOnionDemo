using Microsoft.EntityFrameworkCore;
using MiniEshop.Application.Repositories.Common;
using MiniEshop.Domain.Entities.Common;
using System.Linq.Expressions;

namespace MiniEshop.Infrastructure.Repositories.Common;

public class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
    where TId : struct
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> Query(bool tracking = true)
    {
        var set = _context.Set<TEntity>();
        return tracking ? set : set.AsNoTracking();
    }

    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter, bool tracking = true)
    {
        return Query(tracking).Where(filter);
    }

    public TEntity? FindById(TId id, bool tracking = true)
    {
        return _context.Find<TEntity>(id);
    }

    public TEntity? FindByFilter(Expression<Func<TEntity, bool>> filter, bool tracking = true)
    {
        return Query(filter, tracking).FirstOrDefault();
    }

    public void Create(TEntity product)
    {
        _context.Add(product);
    }

    public void Create(IEnumerable<TEntity> products)
    {
        _context.AddRange(products);
    }

    public void Update(TEntity product)
    {
        _context.Update(product);
    }

    public void Update(IEnumerable<TEntity> products)
    {
        _context.UpdateRange(products);
    }

    public void Delete(TEntity product)
    {
        _context.Remove(product);
    }

    public void Delete(IEnumerable<TEntity> products)
    {
        _context.RemoveRange(products);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
