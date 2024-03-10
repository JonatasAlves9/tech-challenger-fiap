using Domain.Base;

namespace Domain.Entities;

public class Category : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }

    public static Category Create()
    {
        return new Category();
    }

    public Category SetName(string name)
    {
        Name = name;
        return this;
    }
}