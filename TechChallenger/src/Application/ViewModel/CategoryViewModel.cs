using Domain.Entities;

namespace Application.ViewModel;

public class CategoryViewModel
{
    public Guid? Id { get; set; }
    public string Name { get; private set; }
    
    public static CategoryViewModel ToResult(Category category) => new()
    {
        Id = category.Id,
        Name = category.Name
    };

    public static List<CategoryViewModel> ToResultList(IEnumerable<Category> categories) 
        => categories.Select(category => new CategoryViewModel()
        {
            Id = category.Id,
            Name = category.Name
        }).ToList();
}