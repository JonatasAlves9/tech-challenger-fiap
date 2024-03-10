using Application.UseCases.Interfaces;
using Application.ViewModel;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases
{
    public class OrderUseCase : IOrderUseCase

    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrdersProductsRepository _ordersProductsRepository;
        private readonly IProductsIngredientsRepository _productsIngredientsRepository;
        private readonly IOrdersIngredientsRepository _ordersIngredientsRepository;

        public OrderUseCase(IOrderRepository orderRepository, IOrdersProductsRepository ordersProductsRepository,
            IOrdersIngredientsRepository ordersIngredientsRepository,
            IProductsIngredientsRepository productsIngredientsRepository)
        {
            _orderRepository = orderRepository;
            _ordersProductsRepository = ordersProductsRepository;
            _ordersIngredientsRepository = ordersIngredientsRepository;
            _productsIngredientsRepository = productsIngredientsRepository;
        }


        public IEnumerable<Order> GetAllOrder()
        {
            return _orderRepository.GetAll();
        }

        public OrderViewModel Post(OrderViewModel data)
        {
            try
            {
                var order = Order.CreateOrder(data.CustomerId, data.Discount, Domain.Enums.OrderStatus.Received);

                _orderRepository.Add(order);

                var orderProducts = new List<OrdersProducts>();

                foreach (var productItem in data.OrdersProducts)
                {
                    orderProducts.Add(OrdersProducts.CreateOrdersProducts(order.Id, productItem.ProductId,
                        productItem.Quantity));

                    var ordersIngredients = new List<OrdersIngredients>();

                    var productIngredients = _productsIngredientsRepository.GetByProductId(productItem.ProductId);

                    foreach (var productIngredientItem in productIngredients)
                    {
                        foreach (var ingredientItem in data.OrdersIngredients)
                        {
                            ordersIngredients.Add(OrdersIngredients.CreateOrdersIngredients(
                                productIngredientItem.IngredientId, order.Id, ingredientItem.ProductId,
                                ingredientItem.Quantity));
                        }
                    }

                    _ordersProductsRepository.AddRange(orderProducts);
                    _ordersIngredientsRepository.AddRange(ordersIngredients);
                }

                return OrderViewModel.ToResult(order);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object IsPaid(Guid orderId)
        {
            try
            {
                var order = _orderRepository.GetByIdAsync(orderId).Result;

                return new { message = order.IsPaid ? "Payment approved" : "Payment not founded", IsPaid = order.IsPaid };
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool NextStep(Guid orderId)
        {
            try
            {
                var order = _orderRepository.GetByIdAsync(orderId).Result;

                if (order.Status == Domain.Enums.OrderStatus.Finished) return false;

                order.MoveToNextStep();

                _orderRepository.Update(order);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Order> GetQueue()
        {
            var orders = _orderRepository.GetQueue();

            return orders;
        }

        public object GetOrdersByStatus()
        {
            var orders = _orderRepository.GetOrdersByStatus();

            return orders;
        }
    }
}