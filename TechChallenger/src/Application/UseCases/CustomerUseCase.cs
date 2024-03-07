using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases;

public class CustomerUseCase : ICustomerUseCase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerUseCase(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public void CreateCustomer(Customer customer)
    {
        _customerRepository.Add(customer);
    }

    public Customer? GetByDocument(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;
     
        var document = value.Trim();

        return _customerRepository.GetByDocument(document);
    }
}