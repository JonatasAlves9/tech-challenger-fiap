using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;
using Domain.Enums;

namespace Domain.Entities;

public class Order : BaseEntity, IAggregateRoot
{
    public Order(Guid customerId, double discount, OrderStatus status)
    {
        CustomerId = customerId;
        Discount = discount;
        Status = status;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int Number { get; set; }
    [ForeignKey("CustomerId")]
    public Guid CustomerId { get; private set; }
    public double Discount { get; private set; }
    public OrderStatus Status { get; private set; }

    public static Order CreateOrder(Guid customerId, double discount, OrderStatus status)
    {
        return new Order(customerId, discount,  status);
    }

    public void MoveToNextStep()
    {
        Status = GetNextStatus(Status);
    }

    private OrderStatus GetNextStatus(OrderStatus currentStatus)
    {
        switch (currentStatus)
        {
            case OrderStatus.Received:
                return OrderStatus.InProgress;

            case OrderStatus.InProgress:
                return OrderStatus.Ready;

            case OrderStatus.Ready:
                return OrderStatus.Finished;

            case OrderStatus.Finished:
                return currentStatus;

            default:
                return currentStatus;
        }
    }


}