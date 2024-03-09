using Application.DTOs;
using Application.UseCases;
using Application.ViewModel;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryUseCase _categoryUseCase;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryUseCase categoryUseCase)
        {
            _logger = logger;
            _categoryUseCase = categoryUseCase;
        }

        /// <summary>
        /// Busca todas as categorias.
        /// </summary>
        /// <returns>Uma lista de categorias.</returns>
        [SwaggerOperation(Summary = "Busca todas as categorias.", Description = "Uma lista de categorias disponíveis.")]
        [SwaggerResponse(200, "OK", typeof(IEnumerable<CategoryViewModel>))]
        [HttpGet]
        public IActionResult Get()
        {
         
            return Ok(_categoryUseCase.GetAllCategories());
        }
        
        /// <summary>
        /// Cria uma nova categoria de acordo com a model.
        /// </summary>
        /// <param name="model">Dados da categoria</param>
        /// <returns>Retornará uma mensagem de sucesso caso a categoria seja criada corretamente.</returns>
        /// <exception cref="BadRequestObjectResult">Os dados da categoria estão inválidos.</exception>
        /// <exception cref="ObjectResult">Ocorreu um erro inesperado no servidor.</exception>
        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova categoria.", Description = "Método para criação de uma nova categoria")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public IActionResult CreateCategory([FromBody] CategoryDto.CreateCategory model)
        {
            if (model == null)
            {
                return BadRequest("Invalid category data");
            }

            try
            {
                var viewModel = _categoryUseCase.CreateCategory(model);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating tag: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Atualiza os dados da categoria de acordo com a model
        /// </summary>
        /// <param name="model">Dados da categoria</param>
        /// <returns>Retornará uma mensagem de sucesso caso a categoria seja atualizada corretamente.</returns>
        /// <exception cref="BadRequestObjectResult">Os dados da categoria estão inválidos</exception>
        /// <exception cref="ObjectResult">Ocorreu um erro interno no servidor</exception>
        [HttpPut]
        [SwaggerOperation(Summary = "Edita uma categoria.", Description = "Método para edição de uma categoria")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDto.UpdateCategory model)
        {
            if (model == null)
            {
                return BadRequest("Invalid category data");
            }

            try
            {
                var viewModel = _categoryUseCase.UpdateCategory(model);

                return Ok(viewModel.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating tag: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deleta a categoria de acordo com o ID
        /// </summary>
        /// <param name="id">Identificador da categoria</param>
        /// <returns>Retornará uma mensagem de sucesso caso a categoria seja deletada corretamente.</returns>
        [HttpDelete]
        [SwaggerOperation(Summary = "Deleta uma categoria.", Description = "Método para deletar uma categoria")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public IActionResult RemoveCategory(Guid id)
        {
            try
            {
                _categoryUseCase.RemoveCategory(id);

                return Ok("Category removed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removing category: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}