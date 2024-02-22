using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Common;

namespace Infra.Repositories;

public class IngredientRepository: EfRepository<Ingredient>, IIngredientRepository
{
    public IngredientRepository(TechContext context) : base(context)
    {
    }
}