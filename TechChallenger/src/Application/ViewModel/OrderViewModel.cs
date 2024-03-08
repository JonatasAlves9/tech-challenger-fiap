using Domain.Entities;

namespace Application.ViewModel
{
    public class OrderViewModel
    {
        public Guid? Id { get; set; }
        public Guid CustomerId { get; set; }
        public double Discount { get; set; }
        public IEnumerable<OrdersProductsViewModel>?  OrdersProducts { get; set; }
        public IEnumerable<OrdersIngredientsViewModel>?  OrdersIngredients { get; set; }
        
        public static OrderViewModel ToResult(Order order) => new()
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            Discount = order.Discount
        };

        public static List<OrderViewModel> ToResultList(IEnumerable<Order> orders) 
            => orders.Select(order => new OrderViewModel()
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                Discount = order.Discount
            }).ToList();
    }
}
