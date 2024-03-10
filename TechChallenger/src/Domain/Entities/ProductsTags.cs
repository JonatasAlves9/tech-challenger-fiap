using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.Entities;

public class ProductsTags : BaseEntity, IAggregateRoot
{
    [ForeignKey("Product")]
    public Guid ProductId { get; private set; }
    [ForeignKey("Tag")]
    public Guid TagId { get; private set; }
    #region Virtual
    public virtual Tag Tag { get; set; }
    public virtual Product Product { get; set; }
    #endregion
}