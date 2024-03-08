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
    public int Number { get; private set; }
    [ForeignKey("CustomerId")]
    public Guid CustomerId { get; private set; }
    public double Discount { get; private set; }
    public OrderStatus Status { get; private set; }
    public bool IsPaid { get; private set; } = false;

    // Methods
    
    public void MarkAsPaid()
    {
        IsPaid = true;
    }
    
    public static Order CreateOrder(Guid customerId, double discount, OrderStatus status)
    {
        return new Order(customerId, discount,  status);
    }

    // public static void AddProduct(Order order, Product product, int quantity)
    // {
    //     order.Products.Add(new OrdersProducts(order.Id, product.Id, quantity));
    // }

    // public static void AddIngredient(Order order, Ingredient ingredient, int quantity, Product product)
    // {
    //     order.Ingredients.Add(new OrdersIngredients(ingredient.Id, order.Id, product.Id, quantity));
    // }

    public void MoveToNextStep()
    {
        Status = GetNextStatus(Status);
    }

    public bool IsLastStatus()
        => Status == OrderStatus.Finished;

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