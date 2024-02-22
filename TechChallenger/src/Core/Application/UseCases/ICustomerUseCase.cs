using Domain.Entities;

namespace Application.UseCases;

public interface ICustomerUseCase
{
    void CreateCustomer(Customer customer);
    Customer? GetByDocument(string? document);
}