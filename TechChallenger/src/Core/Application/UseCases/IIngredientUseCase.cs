using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.UseCases
{
    public interface IIngredientUseCase
    {
        IEnumerable<Ingredient> GetAllIngredients();
        void CreateIngredient(IngredientDto ingredient);
        void UpdateIngredient(Ingredient ingredient);
        void RemoveIngredient(Guid id);
    }
}
