using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Common;

namespace Infra.Repositories;

public class CategoryRepository : EfRepository<Category>, ICategoryRepository
{
    public CategoryRepository(TechContext context) : base(context)
    {
    }
}