using Application.ViewModel;
using Domain.Entities;

namespace Application.UseCases
{
    public interface IProductUseCase
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        ProductViewModel CreateProduct(ProductDto.CreateProduct product);
        Task<ProductViewModel> UpdateProductAsync(ProductDto.UpdateProduct product);
        void RemoveProduct(Guid id);
        IEnumerable<ProductViewModel> GetByCategory(Guid id);
    }
}