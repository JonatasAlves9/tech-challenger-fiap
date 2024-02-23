using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases;

public class IngredientUseCase : IIngredientUseCase
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientUseCase(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    public IEnumerable<Ingredient> GetAllIngredients()
    {
        return _ingredientRepository.GetAll();
    }
    public void CreateIngredient(IngredientDto ingredient)
    {
        var model = Ingredient.Create(ingredient.Name, ingredient.Price);
        
        _ingredientRepository.Add(model);
    }

    public void UpdateIngredient(Ingredient model)
    {
        _ingredientRepository.Update(model);
    }

    public void RemoveIngredient(Guid id)
    {
        var ingredient = _ingredientRepository.GetByIdAsync(id).Result;
        _ingredientRepository.Remove(ingredient);
    }
}