using Application.DTOs;
using Application.ViewModel;
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

    public IEnumerable<IngredientViewModel> GetAllIngredients()
    {
        return IngredientViewModel.ToResultList(_ingredientRepository.GetAll());
    }
    public IngredientViewModel CreateIngredient(IngredientDto.CreateIngredient ingredient)
    {
        var newIngredient = Ingredient.Create();

        newIngredient
            .SetName(ingredient.Name)
            .SetPrice(ingredient.Price);
        
        _ingredientRepository.Add(newIngredient);

        return IngredientViewModel.ToResult(newIngredient);
    }

    public async Task<IngredientViewModel> UpdateIngredientAsync(IngredientDto.UpdateIngredient ingredient)
    {
        var existingIngredient = await _ingredientRepository.GetByIdAsync(ingredient.Id);

        if (existingIngredient == null)
        {
            throw new InvalidOperationException("Ingredient not found with the ID provided.");
        }

        existingIngredient
            .SetName(ingredient.Name)
            .SetPrice(ingredient.Price);

        _ingredientRepository.Update(existingIngredient);

        return IngredientViewModel.ToResult(existingIngredient);
    }

    public void RemoveIngredient(Guid id)
    {
        var ingredient = _ingredientRepository.GetByIdAsync(id).Result;
        _ingredientRepository.Remove(ingredient);
    }
}