using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.Entities;

public class ProductsIngredients : BaseEntity, IAggregateRoot
{
    [ForeignKey("Product")]
    public Guid ProductId { get; private set; }
    [ForeignKey("Ingredient")]
    public Guid IngredientId { get; private set; }
    #region Virtual
    public virtual Ingredient Ingredient { get; set; }
    public virtual Product Product { get; set; }
    #endregion
}