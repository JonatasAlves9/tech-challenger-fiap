using Domain.Repositories.Common;
using Domain.Entities;

namespace Domain.Repositories;

public interface IIngredientRepository : IAsyncRepository<Ingredient>
{
}