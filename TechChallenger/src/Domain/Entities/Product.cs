using Domain.Base;

namespace Domain.Entities;

public class Product : BaseEntity, IAggregateRoot
{
    public Product(string name, Guid categoryId, double price, string description, string imageUrl, int estimative)
    {
        Name = name;
        CategoryId = categoryId;
        Price = price;
        Description = description;
        ImageUrl = imageUrl;
        Estimative = estimative;
    }

    public string Name { get; private set; }
    public Guid CategoryId { get; private set; }
    public double Price { get; private set; }
    public string Description { get; private set; }
    public string ImageUrl { get; private set; }
    public int Estimative { get; private set; }

    public static Product CreateProduct(
        string name,
        Guid categoryId,
        double price,
        string description,
        string imageUrl,
        int estimative)
    {
        return new Product(name, categoryId, price, description, imageUrl, estimative);
    }

    public void UpdateProduct(
        string name,
        Guid categoryId,
        double price,
        string description,
        string imageUrl,
        int estimative
    )
    {
        Name = name;
        CategoryId = categoryId;
        Price = price;
        Description = description;
        ImageUrl = imageUrl;
        Estimative = estimative;
    }
}