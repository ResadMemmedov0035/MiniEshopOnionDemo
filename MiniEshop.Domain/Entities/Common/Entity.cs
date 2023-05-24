namespace MiniEshop.Domain.Entities.Common;

public abstract class Entity<TId>
    where TId : struct
{
    public TId Id { get; set; }
}

public abstract class Entity : Entity<Guid>
{

}
