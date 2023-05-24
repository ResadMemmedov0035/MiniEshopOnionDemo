using MiniEshop.Domain.Entities.Common;
using System.Linq.Expressions;

namespace MiniEshop.Application.Repositories.Common;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
    where TId : struct
{
    IQueryable<TEntity> Query(bool tracking = true);
    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter, bool tracking = true);

    TEntity? FindById(TId id, bool tracking = true);
    TEntity? FindByFilter(Expression<Func<TEntity, bool>> filter, bool tracking = true);

    void Create(TEntity product);
    void Create(IEnumerable<TEntity> products);
    void Update(TEntity product);
    void Update(IEnumerable<TEntity> products);
    void Delete(TEntity product);
    void Delete(IEnumerable<TEntity> products);
    void Save();
}
