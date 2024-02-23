using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases;

public class CategoryUseCase : ICategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _categoryRepository.GetAll();
    }
    public void CreateCategory(CategoryDto category)
    {
        var model = Category.Create(category.Name);
    
        _categoryRepository.Add(model);
    }
    public async Task UpdateCategory(Category category)
    {
        _categoryRepository.Update(category);
    }
    public void RemoveCategory(Guid id)
    {
        var category = _categoryRepository.GetByIdAsync(id).Result;
        _categoryRepository.Remove(category);
    }
}