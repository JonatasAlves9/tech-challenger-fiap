using Application.DTOs;
using Application.UseCases;
using Application.UseCases.Interfaces;
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
        public IActionResult CreateTag([FromBody] TagDto.CreateTag tagModel)
        {
            if (tagModel == null)
            {
                return BadRequest("Invalid tag data");
            }

            try
            {
                var viewModel = _tagUseCase.CreateTag(tagModel);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating tag: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateTag([FromBody] TagDto.UpdateTag tagModel)
        {
            if (tagModel == null)
            {
                return BadRequest("Invalid tag data");
            }

            try
            {
                var viewModel = await _tagUseCase.UpdateTag(tagModel);
                
                return Ok(viewModel);
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

                return Ok("Tag removed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating tag: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}