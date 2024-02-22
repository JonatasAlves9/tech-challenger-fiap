using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public interface ICategoryUseCase
    {
        IEnumerable<Category> GetAllCategories();
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void RemoveCategory(Guid id);
    }
}
