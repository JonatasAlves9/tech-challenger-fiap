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

    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.GetAll();
    }

    public object CreateProduct(CreateProductViewModel product)
    {
        var newProduct = Product.CreateProduct(
            product.Name,
            product.CategoryId,
            product.Price,
            product.Description,
            product.ImageUrl,
            product.Estimative
        );

        _productRepository.Add(newProduct);

        return newProduct;
    }

    public object UpdateProduct(UpdateProductViewModel product)
    {
        var existingProduct = _productRepository.GetByIdAsync(product.Id).Result;

        if (existingProduct == null)
        {
            throw new InvalidOperationException("Produto não encontrado com o ID fornecido.");
        }

        existingProduct.UpdateProduct(
            product.Name,
            product.CategoryId,
            product.Price,
            product.Description,
            product.ImageUrl,
            product.Estimative
        );

        _productRepository.Update(existingProduct);

        return product;
    }

    public void RemoveProduct(Guid id)
    {
        var product = _productRepository.GetByIdAsync(id).Result;
        _productRepository.Remove(product);
    }

    public IEnumerable<Product> GetByCategory(Guid id)
    {
        var products = _productRepository.GetByCategory(id);
        return products;
    }
}