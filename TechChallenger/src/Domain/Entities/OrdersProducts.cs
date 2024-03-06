using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.Entities;

public class OrdersProducts : BaseEntity, IAggregateRoot
{
    public OrdersProducts(Guid orderId, Guid productId, int quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    [ForeignKey("Order")]
    public Guid OrderId { get; private set; }
    [ForeignKey("Product")]
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    public static OrdersProducts CreateOrdersProducts(Guid orderId, Guid productId, int quantity)
    {
        return new OrdersProducts(orderId, productId, quantity);
    }
    #region Virtual
    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
    #endregion
}