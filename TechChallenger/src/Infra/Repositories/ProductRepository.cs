using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Common;

namespace Infra.Repositories;

public class ProductRepository : EfRepository<Product>, IProductRepository
{
    public ProductRepository(TechContext context) : base(context)
    {
        
    }

    public IEnumerable<Product> GetByCategory(Guid id)
    {
        var products = _context.Products.Where(p => p.CategoryId == id);

        return products;
    }
}