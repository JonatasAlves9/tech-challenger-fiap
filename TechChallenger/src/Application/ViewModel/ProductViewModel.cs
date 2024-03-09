using Domain.Entities;

namespace Application.ViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid CategoryId { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public int Estimative { get; private set; }

        public static ProductViewModel ToResult(Product product)
            => new()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Estimative = product.Estimative,
            };
        
        public static List<ProductViewModel> ToResultList(IEnumerable<Product> products)
            => products.Select(product => new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Estimative = product.Estimative,
            }).ToList();

    }
}
