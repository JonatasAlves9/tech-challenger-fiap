using Domain.Base;
using Domain.ValueObjects;

namespace Domain.Entities;

public class User : BaseEntity, IAggregateRoot
{
    public User(string name, string mail, string password)
    {
        Name = name;
        Mail = mail;
        Password = password;
    }

    public string Name { get; private set; }
    public string Mail { get; private set; }
    public string Password { get; private set; }
}