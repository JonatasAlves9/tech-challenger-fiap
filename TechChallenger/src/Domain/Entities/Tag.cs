using Domain.Base;

namespace Domain.Entities;

public class Tag : BaseEntity, IAggregateRoot
{
    public Tag(string name, string imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }

    public string Name { get; private set; }
    public string ImageUrl { get; private set; }
}