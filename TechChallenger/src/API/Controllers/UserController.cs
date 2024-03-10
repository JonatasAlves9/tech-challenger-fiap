using Application.UseCases;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserUseCase _userUseCase;

        public UsersController(ILogger<UsersController> logger, IUserUseCase userUseCase)
        {
            _logger = logger;
            _userUseCase = userUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}