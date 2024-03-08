using Domain.Base;
using Domain.Entities;
using Domain.Repositories.Common;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Common;

public abstract class EfRepository<TEntity> : RepositoryBase<TEntity>, IAsyncRepository<TEntity>
    where TEntity : BaseEntity, IAggregateRoot
{
    protected readonly TechContext _context;

    protected EfRepository(TechContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<TEntity> GetAll() =>
        DbSet.AsNoTracking().Where(w => w.DeleteAt == null).ToListAsync().Result;

    public void Add(TEntity entity)
    {
        DbSet.Add(entity);
        SaveChanges();
    }

    public void AddRange(IEnumerable<TEntity> entities) =>
        DbSet.AddRange(entities);

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
        SaveChanges();
    }

    public void UpdateRange(IEnumerable<TEntity> entities) =>
        DbSet.UpdateRange(entities);

    public void Remove(TEntity entity)
    {
        DbSet.Remove(entity);
        SaveChanges();
    }

    public void RemoveRange(IEnumerable<TEntity> entities) =>
        DbSet.RemoveRange(entities);

    private void SaveChanges()
    {
        // Chame o método SaveChanges do DbContext para persistir as alterações no banco de dados.
        _context.SaveChanges();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }
}