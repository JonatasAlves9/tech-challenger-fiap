using Application.ViewModel;
using Domain.Entities;

namespace Application.UseCases.Interfaces
{
    public interface IOrderUseCase 
    {
        IEnumerable<Order> GetAllOrder();
        OrderViewModel Post(OrderViewModel data);
        bool NextStep(Guid orderId);
        IEnumerable<Order> GetQueue();
        object IsPaid(Guid orderId);
        object GetOrdersByStatus();
    }
}
