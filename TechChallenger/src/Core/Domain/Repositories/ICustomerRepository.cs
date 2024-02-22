using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories;

public interface ICustomerRepository : IAsyncRepository<Customer>
{
    Customer? GetByDocument(string document);
}