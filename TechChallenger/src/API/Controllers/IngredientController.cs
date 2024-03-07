using Application.DTOs;
using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly ILogger<IngredientsController> _logger;
        private readonly IIngredientUseCase _ingredientUseCase;

        public IngredientsController(ILogger<IngredientsController> logger, IIngredientUseCase ingredientUseCase)
        {
            _logger = logger;
            _ingredientUseCase = ingredientUseCase;
        }

        /// <summary>
        /// Busca todos os ingredientes.
        /// </summary>
        /// <returns>Uma lista de ingredientes.</returns>
        [SwaggerOperation(Summary = "Busca todos os ingredientes.", Description = "Uma lista de ingredientes disponíveis.")]
        [SwaggerResponse(200, "OK", typeof(IEnumerable<Category>))]
        [HttpGet]
        public IActionResult Get()
        {
         
            return Ok(_ingredientUseCase.GetAllIngredients());
        }
        [HttpPost]
        public IActionResult CreateIngredient([FromBody] IngredientDto.CreateIngredient model)
        {
            if (model == null)
            {
                return BadRequest("Invalid ingredient data");
            }

            try
            {
                var viewModel = _ingredientUseCase.CreateIngredient(model);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating ingredient: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateIngredient([FromBody] IngredientDto.UpdateIngredient model)
        {
            if (model == null)
            {
                return BadRequest("Invalid ingredient data");
            }

            try
            {
                var viewModel = await _ingredientUseCase.UpdateIngredientAsync(model);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating ingredient: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public IActionResult RemoveIngredient(Guid id)
        {
            try
            {
                _ingredientUseCase.RemoveIngredient(id);

                return Ok("Ingredient removed successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removing ingredient: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}