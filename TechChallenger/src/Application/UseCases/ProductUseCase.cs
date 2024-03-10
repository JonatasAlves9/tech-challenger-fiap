using Application.UseCases.Interfaces;
using Application.ViewModel;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases;

public class ProductUseCase : IProductUseCase
{
    private readonly IProductRepository _productRepository;

    public ProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<ProductViewModel> GetAllProducts()
    {
        return ProductViewModel.ToResultList(_productRepository.GetAll());
    }

    public ProductViewModel CreateProduct(ProductDto.CreateProduct product)
    {
        var newProduct = Product.CreateProduct();
        newProduct
            .SetName(product.Name)
            .SetCategoryId(product.CategoryId)
            .SetPrice(product.Price)
            .SetDescription(product.Description)
            .SetImageUrl(product.ImageUrl)
            .SetEstimative(product.Estimative);

        _productRepository.Add(newProduct);

        return ProductViewModel.ToResult(newProduct);
    }

    public async Task<ProductViewModel> UpdateProductAsync(ProductDto.UpdateProduct product)
    {
        var existingProduct = await _productRepository.GetByIdAsync(product.Id);

        if (existingProduct == null)
        {
            throw new InvalidOperationException("Product not found with the ID provided.");
        }

        existingProduct
            .SetName(product.Name)
            .SetCategoryId(product.CategoryId)
            .SetPrice(product.Price)
            .SetDescription(product.Description)
            .SetImageUrl(product.ImageUrl)
            .SetEstimative(product.Estimative);

        _productRepository.Update(existingProduct);

        return ProductViewModel.ToResult(existingProduct);
    }

    public void RemoveProduct(Guid id)
    {
        var product = _productRepository.GetByIdAsync(id).Result;
        _productRepository.Remove(product);
    }

    public IEnumerable<ProductViewModel> GetByCategory(Guid id)
    {
        return ProductViewModel.ToResultList(_productRepository.GetByCategory(id));
    }
}