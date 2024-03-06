using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Common;
using Domain.Enums;

namespace Infra.Repositories
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(TechContext context) : base(context) { }

        public IEnumerable<Order> GetQueue()
        {
            var orders = _context.Orders.Where(o => o.Status != OrderStatus.Finished);

            return orders;
        }


    }
}
