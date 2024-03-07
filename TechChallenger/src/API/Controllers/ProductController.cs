using Application.UseCases;
using Application.UseCases.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductUseCase _productUseCase;

        public ProductController(ILogger<ProductController> logger, IProductUseCase productUseCase)
        {
            _logger = logger;
            _productUseCase = productUseCase;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Get()
        {

            return Ok(_productUseCase.GetAllProducts());
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto.CreateProduct productModel)
        {
            if (productModel == null)
            {
                return BadRequest("Invalid product data");
            }

            try
            {
                var viewModel = _productUseCase.CreateProduct(productModel);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating product: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto.UpdateProduct productModel)
        {
            if (productModel == null)
            {
                return BadRequest("Invalid product data");
            }

            try
            {
                var model = await _productUseCase.UpdateProductAsync(productModel);
                
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating product: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] Guid id)
        {
            if (id == null)
            {
                return BadRequest("Invalid id data");
            }

            try
            {
                _productUseCase.RemoveProduct(id);

                return Ok("Product removed successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating product: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetProductsByCategory")]
        public IActionResult GetProductsByCategory(Guid id)
        {
            if (id == null)
            {
                return BadRequest("Invalid id data");
            }

            try
            {
                var products = _productUseCase.GetByCategory(id);

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error category not found: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}