using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        IEnumerable<Order> GetQueue();
        object GetOrdersByStatus();
    }
}