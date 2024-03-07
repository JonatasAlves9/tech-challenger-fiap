using Application.ViewModel;
using Domain.Entities;

namespace Application.UseCases
{
    public interface IOrderUseCase 
    {
        IEnumerable<OrderViewModel> GetAllOrder();
        OrderViewModel Post(OrderViewModel data);
        bool NextStep(Guid orderId);
        IEnumerable<OrderViewModel> GetQueue();
    }
}
