using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
