using Domain.Base;

namespace Domain.Entities;

public class Ingredient : BaseEntity, IAggregateRoot
{
    public Ingredient(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; private set; }
    public double Price { get; private set; }
}