using Domain.Base;

namespace Domain.Entities;

public class Ingredient : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public double Price { get; private set; }
    public static Ingredient Create()
    {
        return new Ingredient();
    }

    public Ingredient SetName(string name)
    {
        Name = name;
        return this;
    }

    public Ingredient SetPrice(double price)
    {
        Price = price;
        return this;
    }
}