using Application.ViewModel;
using Domain.Entities;

namespace Application.UseCases
{
    public interface IProductUseCase
    {
        IEnumerable<ListProductViewModel> GetAllProducts();
        ProductViewModel CreateProduct(CreateProductViewModel product);
        Task<UpdateProductViewModel> UpdateProductAsync(UpdateProductViewModel product);
        void RemoveProduct(Guid id);
        IEnumerable<ListProductViewModel> GetByCategory(Guid id);
    }
}