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
    public interface ICategoryUseCase
    {
        IEnumerable<CategoryViewModel> GetAllCategories();
        CategoryViewModel CreateCategory(CategoryDto.CreateCategory category);
        Task<CategoryViewModel> UpdateCategory(CategoryDto.UpdateCategory category);
        void RemoveCategory(Guid id);
    }
}
