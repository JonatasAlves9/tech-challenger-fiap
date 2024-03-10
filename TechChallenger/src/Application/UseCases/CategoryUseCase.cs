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
        return CategoryViewModel.ToResultList(_categoryRepository.GetAll());
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
        var existingProduct = await _categoryRepository.GetByIdAsync(category.id);

        if (existingProduct == null)
        {
            throw new InvalidOperationException("Product not found with the ID provided.");
        }
        
        existingProduct
            .SetName(category.Name);

        _categoryRepository.Update(existingProduct);

        return CategoryViewModel.ToResult(existingProduct);
    }
    public void RemoveCategory(Guid id)
    {
        var category = _categoryRepository.GetByIdAsync(id).Result;
        _categoryRepository.Remove(category);
    }
}