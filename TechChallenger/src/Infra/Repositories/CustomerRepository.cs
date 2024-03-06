using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Common;

namespace Infra.Repositories;

public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(TechContext context) : base(context)
    {
    }


    public Customer? GetByDocument(string value)
    {
        
        var customer = _context.Customers.FirstOrDefault(c => c.Document == value);

        return customer ?? null;
    }
}