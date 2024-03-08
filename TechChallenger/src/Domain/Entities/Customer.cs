using Domain.Base;

namespace Domain.Entities;

public class Customer : BaseEntity, IAggregateRoot
{
    public Customer(string name, string document, string mail, string phone, DateTime birthDay)
    {
        Name = name;
        Document = document;
        Mail = mail;
        Phone = phone;
        BirthDay = birthDay;
    }

    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Mail { get; private set; }
    public string Phone { get; private set; }
    public DateTime BirthDay { get; private set; }
}