using Application.UseCases.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderUseCase _orderUseCase;
        public OrderController(IOrderUseCase orderUseCase, ILogger<OrderController> logger)
        {
            _orderUseCase = orderUseCase;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_orderUseCase.GetAllOrder());
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel order)
        {
            if(order == null)  return BadRequest("Invalid order data");

            try
            {
                var result = _orderUseCase.Post(order);

                if(result == null) return BadRequest("Error to create Order");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating order: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("NextStep")]
        public IActionResult NextStep([FromQuery] Guid orderId) 
        {
            if (orderId == Guid.Empty) return BadRequest("Invalid order data");

            try
            {
                if (_orderUseCase.NextStep(orderId)) return Ok("Order status updated");

                return BadRequest("Erro update Order status");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating order: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpGet]
        [Route("GetStatusPayment")]
        public IActionResult GetStatusPayment([FromQuery] Guid orderId)
        {
            if (orderId == Guid.Empty) return BadRequest("Invalid order data");

            try
            {
                var result = _orderUseCase.IsPaid(orderId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error get status payment: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpGet]
        [Route("GetOrdersByStatus")]
        public IActionResult GetOrdersByStatus()
        {
            try
            {
                var result = _orderUseCase.GetOrdersByStatus();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error get orders by status: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetQueue")]
        public IActionResult GetQueue()
        {
            try
            {
                var result = _orderUseCase.GetQueue();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error get queue: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
