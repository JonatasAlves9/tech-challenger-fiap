using Application.ViewModel;
using Domain.Entities;

namespace Application.UseCases
{
    public interface IOrderUseCase 
    {
        IEnumerable<OrderViewModel> GetAllOrder();
        OrderViewModel Post(OrderViewModel data);
        bool NextStep(Guid orderId);
<<<<<<< HEAD
        IEnumerable<OrderViewModel> GetQueue();
=======
        IEnumerable<Order> GetQueue();
        bool IsPaid(Guid orderId);
        object GetOrdersByStatus();
>>>>>>> feature/cleanArchitecture
    }
}
