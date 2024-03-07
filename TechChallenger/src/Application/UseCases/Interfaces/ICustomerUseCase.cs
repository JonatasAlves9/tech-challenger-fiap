using Domain.Entities;

namespace Application.UseCases.Interfaces;

public interface ICustomerUseCase
{
    void CreateCustomer(Customer customer);
    Customer? GetByDocument(string? document);
}