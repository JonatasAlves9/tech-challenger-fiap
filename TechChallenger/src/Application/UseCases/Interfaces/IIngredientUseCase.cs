using Application.DTOs;
using Application.ViewModel;

namespace Application.UseCases
{
    public interface IIngredientUseCase
    {
        IEnumerable<IngredientViewModel> GetAllIngredients();
        IngredientViewModel CreateIngredient(IngredientDto.CreateIngredient ingredient);
        Task<IngredientViewModel> UpdateIngredientAsync(IngredientDto.UpdateIngredient ingredient);
        void RemoveIngredient(Guid id);
    }
}
