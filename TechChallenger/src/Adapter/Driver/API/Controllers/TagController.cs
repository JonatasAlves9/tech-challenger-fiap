using Application.DTOs;
using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ILogger<TagsController> _logger;
        private readonly ITagUseCase _tagUseCase;

        public TagsController(ILogger<TagsController> logger, ITagUseCase tagUseCase)
        {
            _logger = logger;
            _tagUseCase = tagUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {
         
            return Ok(_tagUseCase.GetAllTags());
        }
        
        [HttpPost]
        public IActionResult CreateTag([FromBody] TagDto tagModel)
        {
            if (tagModel == null)
            {
                return BadRequest("Invalid tag data");
            }

            try
            {
                _tagUseCase.CreateTag(tagModel);

                return Ok("Tag Criada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating tag: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpDelete]
        public IActionResult DeleteTag([FromBody] Guid id)
        {
            if (id == null)
            {
                return BadRequest("Invalid id data");
            }

            try
            {
                _tagUseCase.RemoveTag(id);

                return Ok("Tag removida com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating tag: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpPut]
        public IActionResult UpdateIngredient([FromBody] Tag model)
        {
            if (model == null)
            {
                return BadRequest("Invalid tag data");
            }

            try
            {
                _tagUseCase.UpdateTag(model);
                
                return Ok("Tag foi criada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating tag: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
    }
}