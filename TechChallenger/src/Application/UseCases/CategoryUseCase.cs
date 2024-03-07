using Application.DTOs;
using Application.ViewModel;
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

    public IEnumerable<CategoryViewModel> GetAllCategories()
    {
        return CategoryViewModel.List(_categoryRepository.GetAll());
    }
    public CategoryViewModel CreateCategory(CategoryDto.CreateCategory category)
    {
        var newCategory = Category.Create();

        newCategory
            .SetName(category.Name);
    
        _categoryRepository.Add(newCategory);

        return CategoryViewModel.ToResult(newCategory);
    }
    public async Task<CategoryViewModel> UpdateCategory(CategoryDto.UpdateCategory category)
    {
        var newCategory = Category.Create();

        newCategory
            .SetName(category.Name);
        
        _categoryRepository.Add(newCategory);

        return CategoryViewModel.ToResult(newCategory);
    }
    public void RemoveCategory(Guid id)
    {
        var category = _categoryRepository.GetByIdAsync(id).Result;
        _categoryRepository.Remove(category);
    }
}