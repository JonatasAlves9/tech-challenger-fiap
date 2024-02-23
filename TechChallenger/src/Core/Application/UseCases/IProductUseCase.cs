using Application.ViewModel;
using Domain.Entities;

namespace Application.UseCases
{
    public interface IProductUseCase
    {
        IEnumerable<Product> GetAllProducts();
        object CreateProduct(ProductDto product);
        object UpdateProduct(UpdateProductViewModel product);
        void RemoveProduct(Guid id);
        IEnumerable<ListProductViewModel> GetByCategory(Guid id);
    }
}