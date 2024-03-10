using Domain.Base;

namespace Domain.Entities;

public class Tag : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string ImageUrl { get; private set; }
    
    public static Tag Create()
    {
        return new Tag();
    }

    public Tag SetName(string name)
    {
        Name = name;
        return this;
    }

    public Tag SetImageUrl(string url)
    {
        ImageUrl = url;
        return this;
    }
    
}