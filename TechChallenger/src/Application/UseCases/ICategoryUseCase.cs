using Domain.Entities;
using Application.ViewModel;

namespace Application.UseCases
{
    public interface ICategoryUseCase
    {
        IEnumerable<CategoryViewModel> GetAllCategories();
        void CreateCategory(CategoryDto.CreateCategory category);
        void UpdateCategory(CategoryDto.UpdateCategory category);
        void RemoveCategory(Guid id);
    }
}
