using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.Entities;

public class OrdersIngredients : BaseEntity, IAggregateRoot
{
    public OrdersIngredients(Guid ingredientId, Guid orderId, Guid productId, int quantity)
    {
        IngredientId = ingredientId;
        OrderId = orderId;
        Quantity = quantity;
        ProductId = productId;
    }

    [ForeignKey("Ingredient")]
    public Guid IngredientId { get; private set; }

    [ForeignKey("Order")]
    public Guid OrderId { get; private set; }

    [ForeignKey("Product")]
    public Guid ProductId { get; private set; }


    public int Quantity { get; private set; }

    public static OrdersIngredients CreateOrdersIngredients(Guid ingredientId, Guid orderId, Guid productId, int quantity)
    {
        return new OrdersIngredients(ingredientId, orderId, productId, quantity);
    }

    #region Virtual
    public virtual Order Order { get; set; }
    public virtual Ingredient Ingredient { get; set; }
    #endregion
}