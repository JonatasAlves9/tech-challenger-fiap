using Domain.Base;

namespace Domain.Entities;

public class Category : BaseEntity, IAggregateRoot
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public static Category Create(string name)
    {
        return new Category(name);
    }
}