using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerUseCase _customerUseCase;

    public CustomerController(ILogger<CustomerController> logger, ICustomerUseCase customerUseCase)
    {
        _logger = logger;
        _customerUseCase = customerUseCase;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetByDocument(string? document)
    {
        var customer = _customerUseCase.GetByDocument(document);

        if (customer == null)
            return BadRequest("Nenhum cliente foi encontrado!");
        
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult CreateCustomer([FromBody] Customer customer)
    {
        if (customer == null)
            return BadRequest("invalid customer data");

        try
        {
            _customerUseCase.CreateCustomer(customer);

            return Ok("Cliente foi criado com sucesso!");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating tag: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}