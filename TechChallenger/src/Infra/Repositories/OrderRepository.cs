using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Common;
using Domain.Enums;

namespace Infra.Repositories
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(TechContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetQueue()
        {
            var orders = _context.Orders.Where(o => o.Status != OrderStatus.Finished);

            return orders;
        }

        public object GetOrdersByStatus()
        {
            var received = _context.Orders.Where(o => o.Status == OrderStatus.Received).OrderBy(o => o.CreatedAt);
            var inProgress = _context.Orders.Where(o => o.Status == OrderStatus.InProgress).OrderBy(o => o.CreatedAt);
            var ready = _context.Orders.Where(o => o.Status == OrderStatus.Ready).OrderBy(o => o.CreatedAt);

            return new { received, inProgress, ready };
        }
    }
}