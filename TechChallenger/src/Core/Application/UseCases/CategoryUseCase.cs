using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases;

public class CategoryUseCase : ICategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryUseCase(ICategoryRepository CategoryRepository)
    {
        _categoryRepository = CategoryRepository;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _categoryRepository.GetAll();
    }
    public void CreateCategory(Category category)
    {
        _categoryRepository.Add(category);
    }
    public void UpdateCategory(Category category)
    {
        _categoryRepository.Update(category);
    }
    public void RemoveCategory(Guid id)
    {
        var category = _categoryRepository.GetByIdAsync(id).Result;
        _categoryRepository.Remove(category);
    }
}