using Domain.Entities;

namespace Application.ViewModel;

public class IngredientViewModel
{
    public Guid? Id { get; private set; }
    public string Name { get; private set; }
    public double Price { get; private set; }
    
    public static IngredientViewModel ToResult(Ingredient ingredient) => new()
    {
        Id = ingredient.Id,
        Name = ingredient.Name,
        Price = ingredient.Price
    };

    public static List<IngredientViewModel> ToResultList(IEnumerable<Ingredient> ingredients) 
        => ingredients.Select(ingredient => new IngredientViewModel()
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Price = ingredient.Price
        }).ToList();
}