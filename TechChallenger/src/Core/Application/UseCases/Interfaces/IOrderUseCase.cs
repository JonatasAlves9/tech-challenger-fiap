using Application.ViewModel;
using Domain.Entities;

namespace Application.UseCases
{
    public interface IOrderUseCase 
    {
        IEnumerable<Order> GetAllOrder();
        OrderViewModel Post(OrderViewModel data);
        bool NextStep(Guid orderId);
        IEnumerable<Order> GetQueue();
    }
}
