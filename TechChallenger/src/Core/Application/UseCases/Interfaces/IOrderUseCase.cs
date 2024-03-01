﻿using Application.ViewModel;
using Domain.Entities;

namespace Application.UseCases
{
    public interface IOrderUseCase 
    {
        IEnumerable<Order> GetAllOrder();
        object Post(OrderViewModel data);
        bool NextStep(Guid orderId);
        IEnumerable<Order> GetQueue();
    }
}
