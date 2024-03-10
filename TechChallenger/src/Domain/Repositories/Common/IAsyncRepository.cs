using Domain.Base;

namespace Domain.Repositories.Common;

public interface IAsyncRepository<TEntity> : IRepository where TEntity : BaseEntity, IAggregateRoot
{
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);

    // Obs: nao sei se esta certo, mas nao tinha get
    IEnumerable<TEntity> GetAll();
    Task<TEntity> GetByIdAsync(Guid id);
}

public interface IRepository
{
}
