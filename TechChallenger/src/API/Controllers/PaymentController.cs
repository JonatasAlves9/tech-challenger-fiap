using Application.DTOs;
using Application.UseCases.Interfaces;
using Application.ViewModel.MercadoPago;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IPaymentUseCase _paymentUseCase;

        public PaymentController(ILogger<CategoriesController> logger, IPaymentUseCase paymentUseCase)
        {
            _logger = logger;
            _paymentUseCase = paymentUseCase;
        }

        /// <summary>
        /// Cria um QR Code para fazer o pagamento do pedido de acordo com a model.
        /// </summary>
        /// <param name="model">Dados para gerar o QRCode</param>
        /// <returns>Retornará uma mensagem de sucesso caso o QR Code seja criado corretamente.</returns>
        /// <exception cref="BadRequestObjectResult">Os dados do parâmetro estão inválidos.</exception>
        /// <exception cref="ObjectResult">Ocorreu um erro inesperado no servidor.</exception>
        [HttpPost]
        [SwaggerOperation(Summary = "Gera um QR Code para pagameto.", Description = "Método para criação de um QR Code")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("CreateQrCode")]
        public IActionResult CreateQRCode([FromBody] CreateQRCodeDTO model)
        {
            if (model == null)
            {
                return BadRequest("Invalid param data");
            }

            try
            {
                var response = _paymentUseCase.CreateQRCode(model);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating QR Code: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Recebe notificação de pagamento do mercado pago.
        /// </summary>
        /// <param name="model">Dados da notificação de pagamento do mercado pago</param>
        /// <returns>Retornará uma mensagem de sucesso caso o pagamento foi efetuado.</returns>
        /// <exception cref="BadRequestObjectResult">Os dados do parâmetro estão inválidos.</exception>
        /// <exception cref="ObjectResult">Ocorreu um erro inesperado no servidor.</exception>
        [HttpPost]
        [SwaggerOperation(Summary = "Efetua o pagamento do pedido.", Description = "Método para efetuar o pagamento do pedido")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Receipt")]
        public IActionResult Receipt([FromBody] ReceiptViewModel model, Guid orderId)
        {
            if (model == null || orderId == null)
            {
                return BadRequest("Invalid param data");
            }

            try
            {
                var paid = _paymentUseCase.PayingOrder(model, orderId);

                if (!paid)
                    return BadRequest("Payment error");
                
                return Ok("Success payment");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Payment not made: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
