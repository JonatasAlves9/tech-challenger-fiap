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

    public IEnumerable<ListProductViewModel> GetAllProducts()
    {
        return ListProductViewModel.ToResult(_productRepository.GetAll());
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

    public async Task<UpdateProductViewModel> UpdateProductAsync(UpdateProductViewModel product)
    {
        var existingProduct = await _productRepository.GetByIdAsync(product.Id);

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

        return UpdateProductViewModel.ToResult(existingProduct);
    }

    public void RemoveProduct(Guid id)
    {
        var product = _productRepository.GetByIdAsync(id).Result;
        _productRepository.Remove(product);
    }

    public IEnumerable<ListProductViewModel> GetByCategory(Guid id)
    {
        return ListProductViewModel.ToResult(_productRepository.GetByCategory(id));
    }
}