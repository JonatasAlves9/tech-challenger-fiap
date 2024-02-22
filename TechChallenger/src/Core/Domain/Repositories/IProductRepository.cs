using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories;

public interface IProductRepository : IAsyncRepository<Product>
{
    IEnumerable<Product> GetByCategory(Guid id);
}